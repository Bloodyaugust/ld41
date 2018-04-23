using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
	Toolbox _toolbox;

	public void Exit () {
		Application.Quit();
	}

	public void Mute () {
		// WHY IN THE FUCK IS THIS NEEDED
		_toolbox = Toolbox.Instance;

		_toolbox.Muted = !_toolbox.Muted;
	}

	void Start () {
		_toolbox = Toolbox.Instance;
	}
}
