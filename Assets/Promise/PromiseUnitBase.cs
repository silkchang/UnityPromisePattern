using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PromiseUnitBase : MonoBehaviour
{
    [System.NonSerialized]
    public bool
        IsReady = false;
    [System.NonSerialized]
    public List<Action>
        OnError = new List<Action> ();

    public void Deny ()
    {
        foreach (Action e in OnError) {
            e.Invoke ();
        }
    }
}