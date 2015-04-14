using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMax, xMin, yMax, yMin;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public Transform shotSpawn2;
	public float fireRate;

	private float nextFire;

	void Update()
	{
		if(Input.GetButton("Jump") && Time.time > nextFire)
	    {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
		}

	}

	// Physics
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		GetComponent<Rigidbody2D>().velocity = movement * speed;

		GetComponent<Rigidbody2D> ().position = new Vector2
			(
				Mathf.Clamp(GetComponent<Rigidbody2D> ().position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
			);
	}


}
