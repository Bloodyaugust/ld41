using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnimation : MonoBehaviour {
	public string AnimationName;

	Animator _animator;

	void Start () {
		_animator = GetComponent<Animator>();

		_animator.Play(AnimationName, -1, Random.value);
	}
}
