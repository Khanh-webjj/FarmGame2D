using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closeDoor;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.GetComponent<Character>() != null)
		{
			OpenDoor();
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.GetComponent<Character>() != null)
		{
			CloseDoor();
		}
	}

	
	private void OpenDoor()
	{
		openDoor.SetActive(true);
		closeDoor.SetActive(false);
		
	}

	private void CloseDoor()
	{
		closeDoor.SetActive(true);
		openDoor.SetActive(false);
	}

}
