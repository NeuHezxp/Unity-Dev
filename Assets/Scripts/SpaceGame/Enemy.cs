using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
	[SerializeField] float health;
	[SerializeField] protected int points;
	[SerializeField] protected IntEvent scoreEvent;

	[SerializeField] protected GameObject hitPrefab;
	[SerializeField] protected GameObject destroyPrefab;
    [SerializeField] protected AudioSource destroySound;

    public void ApplyDamage(float damage)
	{
		health -= damage;
        destroySound.PlayOneShot(destroySound.clip);
        if (health <= 0)
		{
			scoreEvent?.RaiseEvent(points);
			if (destroyPrefab != null)
			{
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
		else
		{
			if (hitPrefab != null)
			{
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
				
            }
		}
	}
}
