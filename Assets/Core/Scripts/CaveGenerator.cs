using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour {
	public static float CHUNK_WIDTH = 512;

	public GameObject[] CaveBackgrounds;
	public GameObject[] ObstaclePrefabs;

	int _currentChunk;
	Toolbox _toolbox;

	static float OBSTACLE_CHANCE = 0.5f;
	static float OBSTACLE_INTERVAL = 64;

	void GenerateChunk () {
		_currentChunk++;

		float numObstacles = CHUNK_WIDTH / OBSTACLE_INTERVAL;
		for (int i = 0; i < CaveBackgrounds.Length; i++) {
			Instantiate(CaveBackgrounds[i], new Vector3(CHUNK_WIDTH * _currentChunk, 0, 0), Quaternion.identity);
		}
		for (int i = 0; i < numObstacles; i++) {
			if (Random.value <= OBSTACLE_CHANCE) {
				int prefabNum = Random.Range(0, ObstaclePrefabs.Length);
				Instantiate(ObstaclePrefabs[prefabNum], new Vector3(_currentChunk * CHUNK_WIDTH + OBSTACLE_INTERVAL * i - CHUNK_WIDTH / 2, ObstaclePrefabs[prefabNum].transform.position.y, 0), Quaternion.identity);
			}
		}
	}

	void Start () {
		_currentChunk = 1;
		_toolbox = Toolbox.Instance;

		_toolbox.GenerateCaveChunk.AddListener(GenerateChunk);
	}
}
