using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDiscard : MonoBehaviour {
	Toolbox _toolbox;

	void OnMouseUp () {
		_toolbox.Discard.Invoke();
	}

	void Start () {
		_toolbox = Toolbox.Instance;
	}
}
