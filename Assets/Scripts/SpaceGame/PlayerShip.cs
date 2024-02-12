using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable
{
	[SerializeField]private PathFollow pathFolower;
	[SerializeField]GameObject destroyPrefab;
	[SerializeField] GameObject hitPrefab;

	[SerializeField] private IntEvent scoreEvent;
	[SerializeField] private Inventory inventory;
	[SerializeField] private IntVariables score;
	[SerializeField] FloatVariable health;

	private void Start()
	{
		scoreEvent.Subscribe(AddPoints);
		health.value = 100;
	}


	public void AddPoints(int points)
	{
		score.value += points;
		Debug.Log(score.value);
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			inventory.Use();
		}
		if (Input.GetButtonUp("Fire2"))
		{
			inventory.stopUse();
		}


		if (Input.GetKeyDown(KeyCode.Tab)) inventory.nextItem();
		if (Input.GetKeyDown(KeyCode.LeftShift)) inventory.previousItem();

		pathFolower.speed = (Input.GetKey(KeyCode.Space) ? 100 : 80);
		//if (Input.GetKeyDown(KeyCode.W)) pathFolower.speed = 5;
	}


	public void ApplyDamage(float damage)
	{
		health.value -= damage;
		if (health.value <= 0)
		{
			
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
	public void applyHealth(float health)
	{
		this.health.value += health;
		this.health.value = Mathf.Clamp(this.health.value, 0, 100);
	}
}
