using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerStates {
	PLAYER_IDLE,
	PLAYER_CROUCH,
	PLAYER_JUMP
}

public class PlayerController : MonoBehaviour {
	public static Vector3 MOVE = new Vector3(16, 0, 0);
	public static Vector3 MOVE_DOUBLE = new Vector3(32, 0, 0);
	public static Vector3 MOVE_JUMP = new Vector3(0, 12, 0);
	public static Vector3 MOVE_FLOOR = new Vector3(0, -14, 0);

	Animator _animator;
	GameObject _player;
	PlayerStates _animationState;
	Toolbox _toolbox;

	void CenterCamera () {
		Camera.main.transform.position = new Vector3(_player.transform.position.x, 0, -10);
	}

	void Crouch () {
		SetAnimationState(PlayerStates.PLAYER_CROUCH);
		_player.transform.position = new Vector3(_player.transform.position.x, MOVE_FLOOR.y, 0);
		_player.transform.Translate(MOVE);
		CenterCamera();
		_toolbox.PlayerMove.Invoke();
	}

	void Jump () {
		_player.transform.position = new Vector3(_player.transform.position.x, MOVE_JUMP.y, 0);
		SetAnimationState(PlayerStates.PLAYER_JUMP);
		_player.transform.Translate(MOVE);
		CenterCamera();
		_toolbox.PlayerMove.Invoke();
	}

	void Move () {
		SetAnimationState(PlayerStates.PLAYER_IDLE);
		_player.transform.position = new Vector3(_player.transform.position.x, MOVE_FLOOR.y, 0);
		_player.transform.Translate(MOVE);
		CenterCamera();
		_toolbox.PlayerMove.Invoke();
	}

	void MoveDouble () {
		SetAnimationState(PlayerStates.PLAYER_IDLE);
		_player.transform.position = new Vector3(_player.transform.position.x, MOVE_FLOOR.y, 0);
		_player.transform.Translate(MOVE_DOUBLE);
		CenterCamera();
	}

	void SetAnimationState (PlayerStates animationState) {
		_animationState = animationState;

		_animator.Play(_animationState.ToString());
	}

	void Start () {
		_animator = GetComponent<Animator>();
		_player = GameObject.FindWithTag("Player");
		_toolbox = Toolbox.Instance;

		_toolbox.PlayerCrouch.AddListener(Crouch);
		_toolbox.PlayerJump.AddListener(Jump);
		_toolbox.PlayerMoveDouble.AddListener(MoveDouble);

		SetAnimationState(PlayerStates.PLAYER_IDLE);
	}

	void Update () {

	}
}
