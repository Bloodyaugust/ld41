using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveDouble : MonoBehaviour {
	Toolbox _toolbox;

	void Start () {
		_toolbox = Toolbox.Instance;
	}

	void OnMouseUp () {
		_toolbox.PlayerMoveDouble.Invoke();
	}
}
