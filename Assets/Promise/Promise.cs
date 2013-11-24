using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Promise : MonoBehaviour
{
    private List<PromiseUnitBase> mUnits = new List<PromiseUnitBase> ();
    [System.NonSerialized]
    public List<Action>
        OnBegin = new List<Action> ();

    public bool IsReady {
        get {
            foreach (PromiseUnitBase u in mUnits) {
                if (u.IsReady == false) {
                    return false;
                }
            }

            return true;
        }
    }

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

    public Promise Then<C, P> (Action<P> fn) where C : PromiseUnit<P>
    {
        C unit = GetComponent<C> ();
        if (unit == null) {
            return this;
        }

        unit.AfterReady.Add (fn);
        AddUnitList (unit);

        return this;
    }

    public Promise WhenError<C> (Action fn) where C : PromiseUnitBase
    {
        C unit = GetComponent<C> ();
        if (unit == null) {
            return this;
        }
        
        unit.OnError.Add (fn);
        AddUnitList (unit);
        
        return this;
    }

    private void AddUnitList (PromiseUnitBase unit)
    {
        if (!mUnits.Contains (unit)) {
            mUnits.Add (unit);
        }
    }
}
