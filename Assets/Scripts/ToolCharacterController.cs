using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolCharacterController : MonoBehaviour
{
	// Start is called before the first frame update
	CharacterController2D characterController2d;
	Character character;
    Rigidbody2D r2d;
	Animator animator;
	ToolBarController toolBarController;
	[SerializeField] float offsetDistance = 1f;
	[SerializeField] float sizeofInteractabableArea = 1.2f;

	[SerializeField] MarkerManage markermanager;
	[SerializeField] TileMapReadController tileMapReadController;
	[SerializeField] float maxDistance = 1.5f;
	[SerializeField] ToolAction onTilePickup;
	[SerializeField] IconHightLight IconHightLight;
	AttackController attackController;

	Vector3Int selectedTilePosition;
	bool selectable;

	[SerializeField] int weaponEnergyCost = 5;

	private void Awake()
	{
		character = GetComponent<Character>();
		characterController2d = GetComponent<CharacterController2D>();
		r2d = GetComponent<Rigidbody2D>();
		toolBarController = GetComponent<ToolBarController>();
		animator = GetComponent<Animator>();
		attackController = GetComponent<AttackController>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			WeaponAction();
		}

		SelectTile();
		CanSelectCheck();
		Marker();
		if (Input.GetMouseButtonDown(0))
		{
			if(UseToolWorld() == true)
			{
				return;
			}
			UseToolGrid();
		}
	}

	private void WeaponAction()
	{
		Item item = toolBarController.GetItem;
		if (item == null)
		{
			return ;
		}
		if(item.isWeapon == false)
		{
			return;
		}
		EnergyCost(weaponEnergyCost);

		Vector2 position = r2d.position + characterController2d.lastMotionVetor * offsetDistance;

		attackController.Attack(item.damage, characterController2d.lastMotionVetor);

	}

	private void EnergyCost(int energyCost)
	{
		character.GetTired(energyCost);

	}

	private void SelectTile()
	{
		selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
	}
	void CanSelectCheck()
	{
		Vector2 characterPosition = transform.position;
		Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		selectable = Vector2.Distance(characterPosition, cameraPosition)< maxDistance;
		markermanager.Show(selectable);
		IconHightLight.CanSelect = selectable;
	}

	private void Marker()
	{
		markermanager.markedCellPosition = selectedTilePosition;
		IconHightLight.targetPosition = selectedTilePosition;
	}

	private bool UseToolWorld()
	{
		Vector2 position = r2d.position + characterController2d.lastMotionVetor * offsetDistance;
		Item item = toolBarController.GetItem;
		if(item == null)
		{
			return false;
		}
		if(item.onAction == null)
		{
			return false;
		}

		EnergyCost(item.onAction.energyCost);
		animator.SetTrigger("act");
		bool complete = item.onAction.OnApply(position);
		if (complete == true)
		{
			if (item.onItemUsed != null)
			{
				item.onItemUsed.OnItemUsed(item, GameManager.Instance.inventoryContainer);
			}
		}
		return false;
	}
	private void UseToolGrid()
	{
		if(selectable == true)
		{
			Item item = toolBarController.GetItem;
			if(item == null ) {
				PickUpTile();
				return; }
			if(item.onTileMapAction == null) { return; }



			EnergyCost(item.onTileMapAction.energyCost);
			animator.SetTrigger("act");
			bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadController, 	item);
			if(complete == true)
			{
				if(item.onItemUsed != null)
				{
					item.onItemUsed.OnItemUsed(item, GameManager.Instance.inventoryContainer);
				}
			}
		}
	}

	private void PickUpTile()
	{
		if(onTilePickup == null)
		{
			return;
		}
		onTilePickup.OnApplyToTileMap(selectedTilePosition, tileMapReadController, null);
	}
}
