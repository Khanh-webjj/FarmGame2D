using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Tool action/Harvest")]
public class TilePickUpAction : ToolAction
{
	public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
	{
		tileMapReadController.cropsManage.PickUp(gridPosition);

		//tileMapReadController.objectsManager.PickUp(gridPosition);

		return true;
	}
}
