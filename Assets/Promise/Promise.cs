using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Promise : MonoBehaviour
{
	private List<PromiseUnitBase> mUnits = new List<PromiseUnitBase>();
	[System.NonSerialized]
	public List<System.Action> OnBegin = new List<System.Action>();

	public void Run() 
	{
		foreach(System.Action e in OnBegin) {
			e.Invoke();
		}
	}

	public Promise Begin(System.Action fn) {
		OnBegin.Add (fn);
		return this;
	}

	public Promise Then<C, P>(System.Action<P> fn) where C : PromiseUnit<P>
	{
		C unit = GetComponent<C> ();

		if (unit == null) {
			return this;
		}

		unit.AfterReady.Add (fn);
		if (!mUnits.Contains(unit)){
			mUnits.Add(unit);
		}

		return this;
	}

	public Promise WhenError<C>(System.Action fn) where C : PromiseUnitBase
	{
		C unit = GetComponent<C> ();
		
		if (unit == null) {
			return this;
		}
		
		unit.OnError.Add (fn);
		if (!mUnits.Contains(unit)){
			mUnits.Add(unit);
		}
		
		return this;
	}
}
