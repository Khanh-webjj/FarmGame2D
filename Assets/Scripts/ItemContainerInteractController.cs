using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerInteractController : MonoBehaviour
{
    ItemContainer targetItemContainer;
	InventoryController inventoryController;
	[SerializeField] ItemContainerPanel itemContainerPanel;
	Transform openedChest;
	[SerializeField] float maxDistance = 2.5f;

	private void Awake()
	{
		inventoryController = GetComponent<InventoryController>();
	}
	private void Update()
	{
		if(openedChest != null)
		{
			float distance = Vector2.Distance(openedChest.position, transform.position);
			if(distance > maxDistance)
			{
				openedChest.GetComponent<LootContanerInterac>().Close(GetComponent<Character>());
			}
		}
	}


	public void Open(ItemContainer itemContainer, Transform _openedChest)
	{
		targetItemContainer = itemContainer;
		itemContainerPanel.inventory = targetItemContainer;
		inventoryController.Open();
		itemContainerPanel.gameObject.SetActive(true);
		openedChest = _openedChest;
	}
	public void Close()
	{
		inventoryController.Close();
		itemContainerPanel.gameObject.SetActive(false);
		openedChest = null;
	}
}
