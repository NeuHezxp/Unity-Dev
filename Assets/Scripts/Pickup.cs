using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] private PickupType pickupType;
	[SerializeField] GameObject pickupPrefab = null;
	[SerializeField] AudioClip pickupSound = null; // Reference to the sound clip
	private AudioSource audioSource; // Audio source component

	public enum PickupType
	{
		Health,
		TimeBoost,
		Score,
		// Add other types as needed
	}


	void Start()
	{
		audioSource = GetComponent<AudioSource>();
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
			switch (pickupType)
			{
				case PickupType.Health:
					player.AddHealth(10);
					AudioSource.PlayClipAtPoint(pickupSound, transform.position);
					break;
				case PickupType.TimeBoost:
					GameManager.Instance.AddTime(10);
					AudioSource.PlayClipAtPoint(pickupSound, transform.position);
					break;
				case PickupType.Score:
					player.AddPoints(10);
						AudioSource.PlayClipAtPoint(pickupSound,transform.position);
					break;
			}
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);

		}
	}
}


