using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardJump : MonoBehaviour {
	Toolbox _toolbox;

	void Start () {
		_toolbox = Toolbox.Instance;
	}

	void OnMouseUp () {
		_toolbox.PlayerJump.Invoke();
	}
}
