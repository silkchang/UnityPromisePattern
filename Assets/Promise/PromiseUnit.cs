using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PromiseUnit<P> : PromiseUnitBase
{
	[System.NonSerialized]
	public List<System.Action<P>> AfterReady = new List<System.Action<P>>();

	public void Accept(P paramter)
	{
		foreach(System.Action<P> e in AfterReady) {
			e.Invoke(paramter);
		}
	}
}