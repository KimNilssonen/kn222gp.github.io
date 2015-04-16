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



	void Start()
	{

		StartCoroutine (SpawnEnemyWaves ());
	}

	IEnumerator SpawnEnemyWaves()
	{
		//DestoyByContact destroyByContact = gameObject.AddComponent<DestoyByContact>();
		yield return new WaitForSeconds(startWait);
		while (true) 
		{



			for (int i = 0; i < enemyCount; i++) 
			{

				/*if(destroyByContact.Counter == 5)
				{
					Debug.Log("funkar?");
					SpawnSecondEnemy();
				}*/

				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait); 
		}
	} 

	

	void SpawnSecondEnemy()
	{
			Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 3, -1);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(enemy2, spawnPosition, spawnRotation);
	}
}
