using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ItemConvertorData
{
	public ItemSlot itemSlot;
	public float timer;

	public ItemConvertorData()
	{
		itemSlot = new ItemSlot();
	}

}
public class ItemConvertorInteract : Interactable, IPersistant
{
    [SerializeField] Item convertableItem;
    [SerializeField] Item producedItem;
	[SerializeField] int produceItemCount = 1;

    [SerializeField] float timeToProcess = 5f;

	ItemConvertorData data;

	Animator animator;
	private void Start()
	{
		if(data== null)
		{
			data = new ItemConvertorData();
		}
		
		animator = GetComponent<Animator>();
		//Animate();
	}
	public override void Interact(Character character)
	{
		if(data.itemSlot.item == null)
		{
			if (GameManager.Instance.dragAndDropController.Check(convertableItem))
			{
				StartItemProcessing();
			}
		}
		if(data.itemSlot.item != null && data.timer < 0f)
		{
			GameManager.Instance.inventoryContainer.Add(data.itemSlot.item, data.itemSlot.Count);
			data.itemSlot.Clear();
		}
		
	}

	private void StartItemProcessing()
	{
		//Animate();
		animator.SetBool("Working",true);
		data.itemSlot.Copy ( GameManager.Instance.dragAndDropController.itemSlot);
		data.itemSlot.Count = 1;
		GameManager.Instance.dragAndDropController.RemoveItem();

		data.timer = timeToProcess;
	}

	private void Animate()
	{
		animator.SetBool("Working", data.timer> 0f);
	}

	private void Update()
	{
		if(data.itemSlot == null)
		{
			return;
		}
		if(data.timer > 0f)
		{
			data.timer -= Time.deltaTime;
			if(data.timer <= 0f)
			{
				CompleteItemConversion();
			}
		}
	}

	private void CompleteItemConversion()
	{
		animator.SetBool("Working",false);
		data.itemSlot.Clear();
		data.itemSlot.Set(producedItem, produceItemCount);
	}

	public string Read()
	{
		return JsonUtility.ToJson(data);
	}

	public void Load(string jsonString)
	{
		data = JsonUtility.FromJson<ItemConvertorData>(jsonString);
	}
}
