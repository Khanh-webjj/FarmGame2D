using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item[] items;

    private Dictionary<string, Item> nameToItemsDict
        = new Dictionary<string, Item> ();

    private void Awake()
    {
        foreach (Item item in items)
        {
            AddItem (item);
        }
    }

    private void AddItem(Item item)
    {
        if (!nameToItemsDict.ContainsKey(item.data.itemName))
        {
            nameToItemsDict.Add(item.data.itemName, item);
        }
    }

    public Item GetItemByName(string key)
    {
        if (nameToItemsDict.ContainsKey(key))
        {
            return nameToItemsDict[key];
        }
        return null;
    }

}
