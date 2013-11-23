using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PromiseUnitBase : MonoBehaviour
{
	[System.NonSerialized]
	public bool IsReady = false;
	[System.NonSerialized]
	public List<System.Action> OnError = new List<System.Action>();

	public void Deny()
	{
		foreach(System.Action e in OnError) {
			e.Invoke();
		}
	}
}
