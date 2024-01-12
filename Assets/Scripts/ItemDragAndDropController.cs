
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    public ItemSlot itemSlot;
	[SerializeField] GameObject ItemIcon;
	RectTransform iconTransform;
	Image itemIconImage;


	internal void OnClick(ItemSlot itemSlot)
	{
		if(this.itemSlot.item == null)
		{
			this.itemSlot.Copy(itemSlot);
			itemSlot.Clear();
		}
		else
		{
			if(itemSlot.item == this.itemSlot.item)
			{
				itemSlot.Count += this.itemSlot.Count;
				this.itemSlot.Clear();
			}
			else
			{
				Item item = itemSlot.item;
				int count = itemSlot.Count;

				itemSlot.Copy(this.itemSlot);
				this.itemSlot.Set(item, count);
			}
			
		}
		UpdateIcon();
	}

	internal void RemoveItem(int count =1)
	{
		if(itemSlot == null) { return; }

		if (itemSlot.item.stackable)
		{
			itemSlot.Count -= count;
			if(itemSlot.Count <= 0)
			{
				itemSlot.Clear();
			}
		}
		else
		{
			itemSlot.Clear();
		}
		UpdateIcon();
		
	}

	public bool Check(Item item, int count = 1)
	{
		if (itemSlot == null) { return false; }
		if (item.stackable)
		{
			return itemSlot.item == item && itemSlot.Count >= count;
		}
		return itemSlot.item == item;
	}

	private void UpdateIcon()
	{
		if(itemSlot.item == null)
		{
			ItemIcon.SetActive(false);
		}
		else
		{
			ItemIcon.SetActive(true);
			itemIconImage.sprite = itemSlot.item.icon;
		}
	}

	private void Start()
	{
		itemSlot = new ItemSlot();
		iconTransform = ItemIcon.GetComponent<RectTransform>();
		itemIconImage = ItemIcon.GetComponent<Image>();
	}
	private void Update()
	{
		if (ItemIcon.activeInHierarchy == true)
		{
			iconTransform.position = Input.mousePosition;
			if(Input.GetMouseButtonDown(0))
			{
				if (EventSystem.current.IsPointerOverGameObject() == false)
				{
					Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					worldPosition.z= 0;
					ItemSpawnManager.instance.SpawnItem(
						worldPosition, 
						itemSlot.item, 
						itemSlot.Count);
					itemSlot.Clear();
					ItemIcon.SetActive(false);
				}
			}
			
		}
	}
}
