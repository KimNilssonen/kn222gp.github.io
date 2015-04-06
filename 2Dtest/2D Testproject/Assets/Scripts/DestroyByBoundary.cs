using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
	void OnTriggerExit(Collider other)
	{
		// Destroys everything that leaves the trigger.
		Destroy (other.gameObject);
	}
}
