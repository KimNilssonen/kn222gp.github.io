using UnityEngine;
using System.Collections;

public class DestoyByContact : MonoBehaviour 
{
	public GameObject EnemyExplosion;
	public float explosionTime;
	public GameObject PlayerExplosion;
	public int scoreValue;

	private int enemyHealth = 2;
	private int enemy2Health = 6;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) 
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}


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

		// Enemy2Ship. The bigger ships that fires laser.
		if (gameObject.tag == "Enemy2") 
		{
			Destroy (other.gameObject);
			enemy2Health --;

			if (enemy2Health == 0) 
			{

				// If enemy collide, this is the enemy explosion.
				GameObject cloneEnemyExplosion = (GameObject)Instantiate (EnemyExplosion, 
                         new Vector3 (gameObject.GetComponent<Rigidbody2D> ().position.x, 
						             gameObject.GetComponent<Rigidbody2D> ().position.y), 
                         Quaternion.identity);
				Destroy (cloneEnemyExplosion, explosionTime);
				gameController.AddScore(scoreValue);

				Destroy (gameObject);
			}
		}

		// Enemy1Ship. Small suicide ships.
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
				gameController.AddScore(scoreValue);

				Destroy (gameObject);


			}
		}
	}
}
