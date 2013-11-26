using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Promise : MonoBehaviour
{
    [System.NonSerialized]
    public List<Action>
        OnBegin = new List<Action> ();

    public void Run ()
    {
        foreach (Action e in OnBegin) {
            e.Invoke ();
        }
    }

    public Promise Begin (Action fn)
    {
        OnBegin.Add (fn);
        return this;
    }

    public Promise Then<C, P> (Action<P> onAccept, Action<string> onDeny = null) where C : PromiseUnit<P>
    {
        C unit = GetComponent<C> ();
        if (unit == null) {
            return this;
        }

        unit.OnAccept.Add (onAccept);
        if (onDeny != null) {
            unit.OnDeny.Add (onDeny);
        }

        return this;
    }
}