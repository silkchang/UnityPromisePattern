using UnityEngine;
using System.Collections;

public class FirstThing : PromiseUnit<int> {

	public void Run()
	{
		Debug.Log ("First Run");

		StartCoroutine (WaitForSecond());
	}

	IEnumerator WaitForSecond()
	{
		yield return new WaitForSeconds(1);

		Debug.Log ("First CallBack");
		Accept(1);
	}
}