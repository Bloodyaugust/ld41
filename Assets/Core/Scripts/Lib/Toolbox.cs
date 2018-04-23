using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Toolbox : Singleton<Toolbox> {
	protected Toolbox () {}

	public bool Muted = false;
	public CardPlayed CardPlayed = new CardPlayed();
	public UnityEvent Discard = new UnityEvent();
	public UnityEvent GenerateCaveChunk = new UnityEvent();
	public UnityEvent PlayerCrouch = new UnityEvent();
	public UnityEvent PlayerDied = new UnityEvent();
	public UnityEvent PlayerJump = new UnityEvent();
	public UnityEvent PlayerMove = new UnityEvent();
	public UnityEvent PlayerMoveDouble = new UnityEvent();

	int _highScore = 0;
	int _score = 0;
	Text _scoreText;

	void Awake () {
		_scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

		PlayerCrouch.AddListener(AddScore);
		PlayerDied.AddListener(OnPlayerDied);
		PlayerJump.AddListener(AddScore);
		PlayerMoveDouble.AddListener(AddScore);
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnPlayerDied () {
		if (_score > _highScore) {
			_highScore = _score;
		}

		_score = 0;
		SceneManager.LoadScene("main");
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		_scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		_scoreText.text = _score.ToString() + " (" + _highScore + ")";
	}

	void ResetScore () {
		_score = 0;
	}

	void AddScore () {
		_score++;

		_scoreText.text = _score.ToString() + " (" + _highScore + ")";
	}

	static public T RegisterComponent<T> () where T: Component {
		return Instance.GetOrAddComponent<T>();
	}
}
