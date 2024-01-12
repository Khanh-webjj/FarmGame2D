using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
	[SerializeField] ItemContainer inventory;
    public void Craft(CraftingRecipe recipe)
	{
		if(inventory.CheckFreeSpace() == false)
		{
			Debug.Log("Not Enough space to put item after craft");
			return;
		}

		for(int i =0; i < recipe.elements.Count; i++)
		{
			if(inventory.CheckItem(recipe.elements[i]) == false)
			{
				Debug.Log("Crafting recipe are not present in the inventory");
				return;
			}
		}
		

		for (int i = 0; i < recipe.elements.Count; i++)
		{
			inventory.Remove(recipe.elements[i].item, recipe.elements[i].Count);

		}
		inventory.Add(recipe.output.item, recipe.output.Count);
	
	}
}
