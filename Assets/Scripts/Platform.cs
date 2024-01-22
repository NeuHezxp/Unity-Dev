using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] List<Animator> animators; // List of animators

	private void OnTriggerEnter(Collider other)
	{
		// Iterate through all animators and set the trigger
		foreach (Animator animator in animators)
		{
			if (animator != null)
			{
				animator.SetTrigger("Start");
			}
		}
	}
}
