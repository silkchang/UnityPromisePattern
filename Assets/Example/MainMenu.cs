using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Promise))]
[RequireComponent(typeof(FirstThing))]
[RequireComponent(typeof(SecondThing))]
public class MainMenu : MonoBehaviour
{
    private Promise mPromise = null;
    private FirstThing mFirst = null;
    private SecondThing mSecond = null;

    void Awake ()
    {
        mPromise = GetComponent<Promise> ();
        mFirst = GetComponent<FirstThing> ();
        mSecond = GetComponent<SecondThing> ();
    }
    
    void Start ()
    {
        mPromise.
            Begin (First).
            Then<FirstThing, int> (AfterFirst).
            Then<SecondThing, string> (AfterSecond);
    }

    void Update ()
    {

    }

    void OnGUI ()
    {
        if (GUI.Button (new Rect (10, 10, 300, 50), "Strar Promise Pattern Test")) {
            mPromise.Run ();
        }
    }

    void First ()
    {
        mFirst.Run ();
    }

    void AfterFirst (int param)
    {
        Debug.Log ("AfterFirst : " + param.ToString ());
        mSecond.Run ();
    }

    void AfterSecond (string param)
    {
        Debug.Log ("AfterSecond : " + param);
    }
}

