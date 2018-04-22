using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {
	Toolbox _toolbox;

	void OnPlayerMoveDouble () {
		GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");

		for (int i = 0; i < cards.Length; i++) {
			cards[i].transform.Translate(PlayerController.MOVE_DOUBLE);
		}
	}

	void Start () {
		_toolbox = Toolbox.Instance;

		_toolbox.PlayerMoveDouble.AddListener(OnPlayerMoveDouble);
	}
}
