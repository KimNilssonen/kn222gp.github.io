using UnityEngine;
using System.Collections;

public class DestoyByContact : MonoBehaviour 
{
	public GameObject EnemyExplosion;
	public float explosionTime;

	public GameObject PlayerExplosion;


	// Destroy everything that enters the trigger
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Boundary") 
		{
			return;
		}

		if (other.tag == "Player") 
		{
			GameObject clonePlayerExplosion = (GameObject)Instantiate(PlayerExplosion,
			            new Vector3(gameObject.GetComponent<Rigidbody2D>().position.x,
			            			gameObject.GetComponent<Rigidbody2D>().position.y),
                      		Quaternion.identity);
			Destroy (clonePlayerExplosion, explosionTime);
		}

			Destroy (other.gameObject);
			Destroy (gameObject);

			GameObject cloneEnemyExplosion = (GameObject)Instantiate (EnemyExplosion, 
		            new Vector3 (gameObject.GetComponent<Rigidbody2D> ().position.x, 
		            			gameObject.GetComponent<Rigidbody2D> ().position.y), 
		           			 Quaternion.identity);
			Destroy (cloneEnemyExplosion, explosionTime);
	}
}
