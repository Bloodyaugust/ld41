using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour {
	public static float CHUNK_WIDTH = 512;

	public GameObject[] CaveBackgrounds;
	public GameObject[] ItemPrefabs;

	int _currentChunk;
	Toolbox _toolbox;

	static float ITEM_CHANCE = 0.3f;
	static float ITEM_INTERVAL = 64;

	void GenerateChunk () {
		_currentChunk++;

		float numItems = CHUNK_WIDTH / ITEM_INTERVAL;
		for (int i = 0; i < CaveBackgrounds.Length; i++) {
			Instantiate(CaveBackgrounds[i], new Vector3(CHUNK_WIDTH * _currentChunk, 0, 0), Quaternion.identity);
		}
		for (int i = 0; i < numItems; i++) {
			if (Random.value <= ITEM_CHANCE) {
				int prefabNum = Random.Range(0, ItemPrefabs.Length - 1);
				Instantiate(ItemPrefabs[prefabNum], new Vector3(_currentChunk * CHUNK_WIDTH + ITEM_INTERVAL * i - CHUNK_WIDTH / 2, ItemPrefabs[prefabNum].transform.localPosition.y, 0), Quaternion.identity);
			}
		}
	}

	void Start () {
		_currentChunk = 1;
		_toolbox = Toolbox.Instance;

		_toolbox.GenerateCaveChunk.AddListener(GenerateChunk);
	}
}
