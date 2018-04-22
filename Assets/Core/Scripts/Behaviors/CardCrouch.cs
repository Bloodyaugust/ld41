using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCrouch : MonoBehaviour {
	Toolbox _toolbox;

	void Start () {
		_toolbox = Toolbox.Instance;
	}

	void OnMouseUp () {
		_toolbox.PlayerCrouch.Invoke();
	}
}
