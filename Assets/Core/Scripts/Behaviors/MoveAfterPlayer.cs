using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAfterPlayer : MonoBehaviour {
	Toolbox _toolbox;

	static Vector3 BAT_MOVE = new Vector3(-16, 0, 0);

	void Move () {
		transform.Translate(BAT_MOVE);
	}

	void Start () {
		_toolbox = Toolbox.Instance;

		_toolbox.PlayerMove.AddListener(Move);
	}
}
