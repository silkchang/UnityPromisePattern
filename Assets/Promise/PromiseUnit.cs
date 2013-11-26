using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PromiseUnit<P> : MonoBehaviour
{
    [System.NonSerialized]
    public List<Action<string>>
        OnDeny = new List<Action<string>> ();
    [System.NonSerialized]
    public List<Action<P>>
        OnAccept = new List<System.Action<P>> ();

    public void Accept (P paramter)
    {
        foreach (Action<P> e in OnAccept) {
            e.Invoke (paramter);
        }
    }

    public void Deny (string msg)
    {
        foreach (Action<string> e in OnDeny) {
            e.Invoke (msg);
        }
    }
}