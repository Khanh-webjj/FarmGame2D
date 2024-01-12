using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteracController : MonoBehaviour
{
	CharacterController2D characterController;
	Rigidbody2D r2d;
	[SerializeField] float offsetDistance = 1f;
	[SerializeField] float sizeofInteractabableArea = 1.2f;
	Character character;
	private void Awake()
	{ 
		characterController = GetComponent<CharacterController2D>();
		r2d = GetComponent<Rigidbody2D>();
		character = GetComponent<Character>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Interact();
		}
	}
	private void Interact()
	{
		Vector2 position = r2d.position + characterController.lastMotionVetor * offsetDistance;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeofInteractabableArea);

		foreach (Collider2D c in colliders)
		{
			Interactable hit = c.GetComponent<Interactable>();
			if (hit != null)
			{
				hit.Interact(character);
				break;
			}
		}
	}
}
