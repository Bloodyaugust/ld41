﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveDouble : MonoBehaviour {
	Toolbox _toolbox;

	void OnMouseUp () {
		_toolbox.PlayerMoveDouble.Invoke();
	}

	void Start () {
		_toolbox = Toolbox.Instance;
	}
}
