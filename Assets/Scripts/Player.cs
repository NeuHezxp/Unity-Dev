using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
	[SerializeField] TMP_Text scoreText;
	[SerializeField] FloatVariable health;
	[SerializeField] PhysicsCharacterController characterController;
	[Header("Events")]
	[SerializeField] IntEvent scoreEvent = default;
	[SerializeField] VoidEvent gameStartEvent = default;
	[SerializeField] VoidEvent PlayerDeadEvent = default;

	//speed boost
	private float originalSpeed; // To store the original speed
	private bool isBoosted = false; // To check if currently boosted

	private int score = 0;

	public int Score
	{
		get { return score; }
		set
		{
			score = value; scoreText.text = score.ToString();
			scoreEvent.RaiseEvent(Score);
		}
	}


	private void OnEnable()
	{
		gameStartEvent.Subscribe(OnStartGame);
	}

	private void Start()
	{
		health.value = 50;
	}

	public void AddPoints(int points)
	{
		Score += points;
	}
	public void AddHealth(float hp)
	{
		health.value += hp;
	}

	private void OnStartGame()
	{
		characterController.enabled = true;
	}
	public void Damage(float damage)
	{
		health.value -= damage;
		if(health.value <= 0){
            PlayerDeadEvent.RaiseEvent();
        }
    }
	public void onRespawn(GameObject respawnPoint)
	{
        transform.position = respawnPoint.transform.position;
        transform.rotation = respawnPoint.transform.rotation;
		characterController.Reset();
    }
	
}