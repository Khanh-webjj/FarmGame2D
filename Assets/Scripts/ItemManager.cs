using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Collectable[] collectableItems;

    private Dictionary<CollectableType, Collectable> collectableItemsDict
        = new Dictionary<CollectableType, Collectable> ();

    private void Awake()
    {
        foreach (Collectable item in collectableItems)
        {
            AddItem (item);
        }
    }

    private void AddItem(Collectable item)
    {
        if (!collectableItemsDict.ContainsKey(item.type))
        {
            collectableItemsDict.Add(item.type, item);
        }
    }

    public Collectable GetItemByType(CollectableType type)
    {
        if (collectableItemsDict.ContainsKey(type))
        {
            return collectableItemsDict[type];
        }
        else
        {
            return null;
        }
    }


    public int DictCount()
    {
        return collectableItemsDict.Count;
    }
    public bool DictIsEmpty()
    {
        return collectableItemsDict.Count == 0;
    }
    public string DictInfor()
    {
        string infor = "";
        foreach (KeyValuePair<CollectableType, Collectable> kvp in collectableItemsDict)
        {
            infor += ("Key = {0} + Value = {1}" + kvp.Key + kvp.Value.ToString()) + "\n";
        }
        return infor;
    }
}
