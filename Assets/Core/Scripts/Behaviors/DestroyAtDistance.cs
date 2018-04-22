using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtDistance : MonoBehaviour {
	GameObject _player;
	Toolbox _toolbox;

	void DetermineDestroy () {
		if (Mathf.Abs(_player.transform.position.x - gameObject.transform.position.x) > CaveGenerator.CHUNK_WIDTH * 3) {
			Destroy(gameObject);
		}
	}

	void Start () {
		_player = GameObject.FindWithTag("Player");
		_toolbox = Toolbox.Instance;

		_toolbox.PlayerMoveDouble.AddListener(DetermineDestroy);
	}
}
