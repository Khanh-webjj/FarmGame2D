using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableControls : MonoBehaviour
{
    CharacterController2D CharacterController2D;
    ToolCharacterController toolCharacter;
    InventoryController inven;
	ToolBarController toolBar;
	ItemContainerInteractController itemcontain;
	private void Awake()
	{
		CharacterController2D = GetComponent<CharacterController2D>();
		toolCharacter = GetComponent<ToolCharacterController>();
		inven = GetComponent<InventoryController>();
		toolBar = GetComponent<ToolBarController>();
		itemcontain = GetComponent<ItemContainerInteractController>();
	}
	public void DisableControl()
	{
		CharacterController2D.enabled = false;
		toolCharacter.enabled = false;
		inven.enabled = false;
		toolBar.enabled = false;
		itemcontain.enabled = false;
	}
	public void EnableControl()
	{
		CharacterController2D.enabled = true;
		toolCharacter.enabled = true;
		inven.enabled = true;
		toolBar.enabled = true;
		itemcontain.enabled = true;
	}
}
