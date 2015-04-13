using UnityEngine;
using System.Collections;

public class DestoyByContact : MonoBehaviour 
{
	// Destroy everything that enters the trigger
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Boundary") 
		{
			return;
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
