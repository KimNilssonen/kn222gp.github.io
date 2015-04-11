﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public int hazardCount;
	public Vector3 spawnValues;

	public float spawnWait;
	public float startWait;

	void Start()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		for (int i = 0; i < hazardCount; i++) 
		{

			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 6, -1);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazard, spawnPosition, spawnRotation);

			yield return new WaitForSeconds(spawnWait);
		}
	}
}
