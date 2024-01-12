using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObjectReferenceManager : MonoBehaviour
{
    public PlaceableObjectsManager PleaceableObjectsManager;

    public void Place(Item item, Vector3Int pos)
	{
		if(PleaceableObjectsManager == null)
		{
			Debug.LogWarning("No place");
			return;
		}
		PleaceableObjectsManager.place(item, pos);
	}

	/*internal void PickUp(Vector3Int gridPosition)
	{
		if (PleaceableObjectsManager == null)
		{
			Debug.LogWarning("No place");
			return;
		}
		PleaceableObjectsManager.PickUp(gridPosition);
	}*/

	/*public bool Check(Vector3Int pos)
	{
		if (PleaceableObjectsManager == null)
		{
			Debug.LogWarning("No place");
			return false;
		}
		
		return PleaceableObjectsManager.Check(pos);
	}*/
}
