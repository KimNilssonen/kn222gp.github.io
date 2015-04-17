using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject enemy;
	public GameObject enemy2;

	public int enemyCount;

	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float waveWait;


	private int score;
	private int shipsDestroyed = 0;

	void Start()
	{
		score = 0;
		StartCoroutine (SpawnEnemyWaves ());
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	

	// Enemy1Ship. Spawning the small suicide enemies.
	IEnumerator SpawnEnemyWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true) 
		{


			for (int i = 0; i < enemyCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait); 
		}
	} 


	// Enemy2Ship. Spawning the second enemy which fires laser.
	void SpawnSecondEnemy()
	{
			Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 3, -1);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(enemy2, spawnPosition, spawnRotation);
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();

		if (score%140 == 0) 
		{
			SpawnSecondEnemy();
		}
	}

	void UpdateScore()
	{
		Debug.Log (score);
	}
}
