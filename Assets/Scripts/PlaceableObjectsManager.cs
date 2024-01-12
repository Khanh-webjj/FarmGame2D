using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceableObjectsManager : MonoBehaviour
{
	[SerializeField] PlaceableObjectsContainer PlaceableObjects;
	[SerializeField] Tilemap targerTileMap;

	private void Start()
	{
		GameManager.Instance.GetComponent<PlaceableObjectReferenceManager>().PleaceableObjectsManager = this;
		VisualizeMap();
	}

	private void OnDestroy()
	{
		for (int i = 0; i < PlaceableObjects.placeableObjects.Count; i++)
		{
			if (PlaceableObjects.placeableObjects[i].targetObject == null)
			{
				continue;
			}

			IPersistant persistant = PlaceableObjects.placeableObjects[i].targetObject.GetComponent<IPersistant>();
			if(persistant != null)
			{
				string jsonString = persistant.Read();
				PlaceableObjects.placeableObjects[i].objectState = jsonString;
			}

			PlaceableObjects.placeableObjects[i].targetObject = null;
		}
	}

	/*internal void PickUp(Vector3Int gridPosition)
	{
		PlaceableObject placedObject = null; //PlaceableObjects.Get(gridPosition);
		if(placedObject == null)
		{
			return;
		}
		ItemSpawnManager.instance.SpawnItem(targerTileMap.CellToWorld(gridPosition),
			placedObject.placedItem,
			1);
		Destroy(placedObject.targetObject.gameObject);
		PlaceableObjects.Remove(placedObject);
	}*/

	private void VisualizeMap()
	{
		for(int i = 0; i< PlaceableObjects.placeableObjects.Count; i++)
		{
			VisualizeItem(PlaceableObjects.placeableObjects[i]);
		}
	}

	private void VisualizeItem(PlaceableObject placeableObject)
	{
		GameObject go = Instantiate(placeableObject.placedItem.itemPrefab);

		go.transform.parent = transform;

		Vector3 position =
			targerTileMap.CellToWorld(placeableObject.positionOnGrid)
			+ targerTileMap.cellSize / 2;
		position -= Vector3.forward * 0.1f;
		go.transform.position = position;

		IPersistant persistant = go.GetComponent<IPersistant>();
		if(persistant != null)
		{
			persistant.Load(placeableObject.objectState);
		}

		placeableObject.targetObject = go.transform;
	}

	/*public bool Check(Vector3Int position)
	{
		return PlaceableObjects.Get(position) != null;
	}*/
	public void place(Item item, Vector3Int positionOnGrid)
	{
		/*if(Check(positionOnGrid) == true)
		{
			return;
		}*/
		PlaceableObject placeableObject = new PlaceableObject(item, positionOnGrid);
		VisualizeItem(placeableObject);
		PlaceableObjects.placeableObjects.Add(placeableObject);
	}
}
