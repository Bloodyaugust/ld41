using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Toolbox : Singleton<Toolbox> {
	protected Toolbox () {}

	public UnityEvent GenerateCaveChunk = new UnityEvent();
	public UnityEvent PlayerMoveDouble = new UnityEvent();

	void Awake () {

	}

	static public T RegisterComponent<T> () where T: Component {
		return Instance.GetOrAddComponent<T>();
	}
}
