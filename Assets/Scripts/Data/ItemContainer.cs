using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [Serializable]
public class ItemSlot
{
    public Item item;
    public int Count;
    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        Count = slot.Count;
    }

    public void Set(Item item,int count)
    {
        this.item = item;
        this.Count = count;
    }
    public void Clear()
    {
        item = null;
        Count = 0;
    }
}
[CreateAssetMenu(menuName = "Data/ItemContainer")]


public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots ;
    public bool isDirty;

    internal void Init()
    {
        slots = new List<ItemSlot>();
        for(int i = 0; i <8; i++)
		{
            slots.Add(new ItemSlot());
		}
    }


    public void Add(Item item,int count = 1)
    {
        isDirty = true;
        if (item.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(x=>x.item == item);
            if(itemSlot != null)
            {
                itemSlot.Count += count;
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if(itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.Count = count;
                }
            }
        }
        else
        {
           ItemSlot itemSlot =  slots.Find(x => x.item == null);
            if(itemSlot == null)
            {
                itemSlot.item = item;
            }
        }
    }
    public void Remove(Item itemToRemove, int count = 1)
	{
        isDirty = true;
        if (itemToRemove.stackable)
		{
            ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
            if(itemSlot == null) { return; }

            itemSlot.Count -= count;
            if(itemSlot.Count <= 0)
			{
                itemSlot.Clear();
			}
		}
		else
		{
            while(count > 0)
			{
                count -= 1;

                ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
                if(itemSlot == null) { break; }
                itemSlot.Clear();
			}
		}
	}

	internal bool CheckFreeSpace()
	{
        for(int i = 0; i< slots.Count ;i++)
		{
            if(slots[i].item == null)
			{
                return true;
			}
		}

        return false;
	}

	internal bool CheckItem(ItemSlot checkingItem)
	{
        ItemSlot itemSlot = slots.Find(x => x.item == checkingItem.item);
        if(itemSlot == null)
		{
            return false;
		}
		if (checkingItem.item.stackable)
		{
            return itemSlot.Count > checkingItem.Count;
		}
        return true;
	}

	
}
