using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
	public override void OnClick(int id)
	{
		GameManager.Instance.dragAndDropController.OnClick(inventory.slots[id]);
		Show();
	}

	/*[SerializeField] ItemContainer inventory;
	[SerializeField] List<InventoryButton> buttons;
	private void Start()
	{
		SetIndex();
		Show();
	}
	private void OnEnable()
	{
		Show();
	}

	private void SetIndex()
	{ 
		for(int i = 0 ;i< inventory.slots.Count && i <buttons.Count; i++)
		{
			buttons[i].SetIndex(i);
		}
	}

	public void Show()
	{
		for(int  i=0; i < inventory.slots.Count && i < buttons.Count; i++)
		{
			if (inventory.slots[i].item == null)
			{
				buttons[i].Clean();
			}
			else
			{
				buttons[i].Set(inventory.slots[i]);
			}
		}
	}*/
}
