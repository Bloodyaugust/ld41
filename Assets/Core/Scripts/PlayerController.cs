using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public static Vector3 MOVE_DOUBLE = new Vector3(32, 0, 0);

	GameObject _player;
	Toolbox _toolbox;

	void CenterCamera () {
		Camera.main.transform.localPosition = new Vector3(_player.transform.localPosition.x, 0, -10);
	}

	void MoveDouble () {
		_player.transform.Translate(MOVE_DOUBLE);
		CenterCamera();

		if (_player.transform.localPosition.x % CaveGenerator.CHUNK_WIDTH == 0) {
			_toolbox.GenerateCaveChunk.Invoke();
		}
	}

	void Start () {
		_player = GameObject.FindWithTag("Player");
		_toolbox = Toolbox.Instance;

		_toolbox.PlayerMoveDouble.AddListener(MoveDouble);
	}

	void Update () {

	}
}
