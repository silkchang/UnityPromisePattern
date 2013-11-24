using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PromiseUnit : PromiseUnitBase
{
    [System.NonSerialized]
    public List<Action>
        AfterReady = new List<Action> ();
    
    public void Accept ()
    {
        IsReady = true;
        foreach (Action e in AfterReady) {
            e.Invoke ();
        }
    }
}

public class PromiseUnit<P> : PromiseUnitBase
{
    [System.NonSerialized]
    public List<Action<P>>
        AfterReady = new List<System.Action<P>> ();

    public void Accept (P paramter)
    {
        IsReady = true;
        foreach (Action<P> e in AfterReady) {
            e.Invoke (paramter);
        }
    }
}