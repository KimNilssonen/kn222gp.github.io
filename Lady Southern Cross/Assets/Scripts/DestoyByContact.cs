using UnityEngine;
using System.Collections;

public class DestoyByContact : MonoBehaviour 
{
	public GameObject EnemyExplosion;
	public float explosionTime;
	public GameObject PlayerExplosion;

	private int enemyHealth = 2;
	private int enemy2Health = 6;

	private int shipsDestroyed = 0;

	// Destroy everything that enters the trigger
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Enemy2") 
		{
			return;
		}

		// If player collide, this is the player explosion.
		if (other.tag == "Player") 
		{
			GameObject clonePlayerExplosion = (GameObject)Instantiate (PlayerExplosion,
			            new Vector3 (gameObject.GetComponent<Rigidbody2D> ().position.x,
			            			gameObject.GetComponent<Rigidbody2D> ().position.y),
                      		Quaternion.identity);
			Destroy (clonePlayerExplosion, explosionTime);

			Destroy (other.gameObject);
			Destroy (gameObject);

		} 


		if (gameObject.tag == "Enemy2") 
		{
			Destroy (other.gameObject);
			enemy2Health --;

			if (enemy2Health < 0) 
			{

				// If enemy collide, this is the enemy explosion.
				GameObject cloneEnemyExplosion = (GameObject)Instantiate (EnemyExplosion, 
                         new Vector3 (gameObject.GetComponent<Rigidbody2D> ().position.x, 
						             gameObject.GetComponent<Rigidbody2D> ().position.y), 
                         Quaternion.identity);
				Destroy (cloneEnemyExplosion, explosionTime);

				Destroy (gameObject);
			}
		}

		else 
		{
			Destroy (other.gameObject);
			enemyHealth --;

			if(enemyHealth == 0)
			{
				// If enemy collide, this is the enemy explosion.
				GameObject cloneEnemyExplosion = (GameObject)Instantiate (EnemyExplosion, 
	                      new Vector3 (gameObject.GetComponent<Rigidbody2D> ().position.x, 
										gameObject.GetComponent<Rigidbody2D> ().position.y), 
	                      Quaternion.identity);
				Destroy (cloneEnemyExplosion, explosionTime);

				Destroy (gameObject);
				Counter++;


			}
		}
	}

	void Update()
	{
		Debug.Log (Counter);
	}

	
		

	public int Counter
	{
		get
		{
			return shipsDestroyed;
		}
		set
		{
			shipsDestroyed = value;
		}
	}
}
