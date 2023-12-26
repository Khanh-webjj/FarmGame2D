using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public Player player;

    public List<Slot_UI> slots = new List<Slot_UI>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
            Refresh();
        }    
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
        } 
        else
        {
            inventoryPanel.SetActive(false);
        }
    } 

    void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotID)
    {
        Collectable itemToDrop
            = GameManager.instance.itemManager.GetItemByType(player.inventory.slots[slotID].type);
        Debug.Log(
            ("type: " + player.inventory.slots[slotID].type) + "\n" +
            ("does itemToDrop exist: " + (itemToDrop!=null ? "yes" :  "no")) + "\n" +
            ("amount of item in ColDict : " + GameManager.instance.itemManager.DictCount()) + "\n" +
            ("ColDict : " + GameManager.instance.itemManager.DictInfor())
        );

        if (itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotID);
            Refresh();
        }
        
    }
}