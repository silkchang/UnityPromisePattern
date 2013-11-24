using UnityEngine;
using System.Collections;

public class SecondThing : PromiseUnit<string>
{
    public void Run ()
    {
        Debug.Log ("Second Run");
        
        StartCoroutine (WaitForSecond ());
    }
    
    IEnumerator WaitForSecond ()
    {
        yield return new WaitForSeconds (1);
        
        Debug.Log ("Second CallBack");
        Accept ("string");
    }
}
