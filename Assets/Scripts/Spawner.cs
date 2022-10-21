using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawn;

	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;

	Vector2 screenHalfSize;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn) {
            // Linear Interpolation a,b,p => value = a + (b-a) p
            float SpawnRate = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawn = Time.time + SpawnRate;
			float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize);
			GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
		}
    }
}
