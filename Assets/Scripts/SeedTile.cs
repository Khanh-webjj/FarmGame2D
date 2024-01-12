using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Tool action/Seed Tile")]
public class SeedTile : ToolAction
{
	public override bool OnApplyToTileMap(Vector3Int gridPosition,
		TileMapReadController tileMapReadController, Item item)
	{
		if(tileMapReadController.cropsManage.Check(gridPosition )== false)
		{
			return false;
		}

		tileMapReadController.cropsManage.Seed(gridPosition,item.crop);


		return true;
	}
	public override void OnItemUsed(Item usedItem, ItemContainer inventory)
	{
		inventory.Remove(usedItem);
	}
}
