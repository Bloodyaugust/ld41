using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCaveWhenPassed : MonoBehaviour {
	bool _generated = false;
	GameObject _player;
	Toolbox _toolbox;

	void CheckIfGenerate () {
		if (_player.transform.position.x > transform.position.x && !_generated) {
			_generated = true;
			_toolbox.GenerateCaveChunk.Invoke();
		}
	}

	void Start () {
		_player = GameObject.FindWithTag("Player");
		_toolbox = Toolbox.Instance;

		_toolbox.PlayerMoveDouble.AddListener(CheckIfGenerate);
		_toolbox.PlayerMove.AddListener(CheckIfGenerate);
	}
}
