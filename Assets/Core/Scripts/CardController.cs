using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CardPlayed : UnityEvent<float>{}

public class CardController : MonoBehaviour {
	public AudioClip ClipCardPlayed;
	public GameObject[] CardPrefabs;

	AudioSource _audioSource;
	Toolbox _toolbox;

	void GenerateCard (float xPosition) {
		GameObject selectedCard = CardPrefabs[Random.Range(0, CardPrefabs.Length)];
		Instantiate(selectedCard, new Vector3(xPosition, selectedCard.transform.position.y, 0), Quaternion.identity);
	}

	void OnCardPlayed (float xPosition) {
		GenerateCard(xPosition);

		if (!_toolbox.Muted) {
			_audioSource.PlayOneShot(ClipCardPlayed, 0.5f);
		}
	}

	void OnDiscard () {
		GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");

		for (int i = 0; i < cards.Length; i++) {
			float xPosition = cards[i].transform.position.x;

			Destroy(cards[i]);
			GenerateCard(xPosition);
		}

		if (!_toolbox.Muted) {
			_audioSource.PlayOneShot(ClipCardPlayed, 0.5f);
		}
	}

	void OnPlayerMove () {
		GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");

		for (int i = 0; i < cards.Length; i++) {
			cards[i].transform.Translate(PlayerController.MOVE);
		}
	}

	void OnPlayerMoveDouble () {
		GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");

		for (int i = 0; i < cards.Length; i++) {
			cards[i].transform.Translate(PlayerController.MOVE_DOUBLE);
		}
	}

	void Start () {
		_audioSource = GetComponent<AudioSource>();
		_toolbox = Toolbox.Instance;

		_toolbox.CardPlayed.AddListener(OnCardPlayed);
		_toolbox.Discard.AddListener(OnDiscard);
		_toolbox.PlayerMoveDouble.AddListener(OnPlayerMoveDouble);
		_toolbox.PlayerMove.AddListener(OnPlayerMove);
	}
}
