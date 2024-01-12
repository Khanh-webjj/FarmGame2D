using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarController : MonoBehaviour
{
    [SerializeField] int toolbarSize = 5;
    int selectedTool;

	public Action<int> onChange;
	[SerializeField] IconHightLight iconHightLight;

	public Item GetItem
	{
		get
		{
			return GameManager.Instance.inventoryContainer.slots[selectedTool].item;
		}
	}

	private void Start()
	{
		onChange += UpdateHightLightIcon;
		UpdateHightLightIcon(selectedTool);
	}
	internal void Set(int id)
	{
		selectedTool = id;
	}

	private void Update()
	{
		float delta = Input.mouseScrollDelta.y;
		if(delta != 0)
		{
			if(delta > 0)
			{

				selectedTool += 1;
				selectedTool = (selectedTool >= toolbarSize ? 0 : selectedTool);
			}
			else
			{
				selectedTool -= 1;
				selectedTool = (selectedTool < 0 ? toolbarSize-1 : selectedTool);
			}
			onChange?.Invoke(selectedTool);
		}
		 
	}
	public void UpdateHightLightIcon(int id = 0)
	{
		Item item = GetItem;
		if(item == null)
		{
			iconHightLight.Show = false;
			return;
		}
		iconHightLight.Show = item.iconHightLight;
		if (item.iconHightLight)
		{
			iconHightLight.Set(item.icon);
		}
	}
}
