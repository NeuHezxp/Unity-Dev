using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
	[SerializeField] VoidEvent gameEndEvent;
	private void OnTriggerEnter(Collider other)
	{
			Debug.Log("Triggered");
			gameEndEvent.RaiseEvent();
	}
}
