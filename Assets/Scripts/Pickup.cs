using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] GameObject pickupPrefab = null;
	[SerializeField] AudioClip pickupSound = null; // Reference to the sound clip
	private AudioSource audioSource; // Audio source component


	void Start()
	{

	}

	void Update()
	{

	}

	private void OnCollisionEnter(Collision collision)
	{
		print(collision.gameObject.name);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<Player>(out Player player))
		{
			player.AddPoints(10);

			// Play the pickup sound if the AudioSource and AudioClip are available
			if (audioSource != null && pickupSound != null)
			{
				audioSource.PlayOneShot(pickupSound);
			}

			Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}

