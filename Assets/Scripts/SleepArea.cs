using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepArea : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Sleep sleep = collision.GetComponent<Sleep>();
		if (sleep != null)
		{
			sleep.DoSleep();
		}
	}
}
