using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCardPlayed : MonoBehaviour {
	Toolbox _toolbox;

	void OnMouseUp () {
		_toolbox.CardPlayed.Invoke(transform.position.x);

		Destroy(gameObject);
	}

	void Start () {
		_toolbox = Toolbox.Instance;
	}
}
