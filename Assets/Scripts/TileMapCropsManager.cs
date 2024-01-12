using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapCropsManager : TimeAgent
{
	[SerializeField] TileBase plowed;
	[SerializeField] TileBase seeded;

	Tilemap targetTileMap;
	

	[SerializeField] CropContainer container;

	[SerializeField] GameObject cropsSpritePrefads;
	private void Start()
	{
		GameManager.Instance.GetComponent<CropsManager>().cropsManager = this;
		targetTileMap = GetComponent<Tilemap>();
		onTimeTick += Tick;
		Init();
		VisualizeMap();
	}

	private void VisualizeMap()
	{
		for (int i = 0; i < container.crops.Count; i++)
		{
			VisualizeTile(container.crops[i]);
		}
	}

	public void OnDestroy()
	{
		for(int i =0; i < container.crops.Count; i++)
		{
			container.crops[i].renderer = null;
		}
	}
	public void Tick()
	{
		if (targetTileMap == null)
		{
			return;
		}
		foreach (CropsTile cropTile in container.crops)
		{
			if(cropTile.crop == null) { continue; }

			cropTile.damage += 0.02f;
			if(cropTile.damage > 1f)
			{
				cropTile.Harvested();
				targetTileMap.SetTile(cropTile.position, plowed);
				continue;
			}

			if (cropTile.Complete)
			{
				Debug.Log("...");
				continue;
			}

			cropTile.growTimer += 1;
			
			if(cropTile.growTimer >= cropTile.crop.growthStageTime[cropTile.growStage])
			{
				cropTile.renderer.gameObject.SetActive(true);
				cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage];
				cropTile.growStage += 1;
			}
			
		}
	}

	internal bool Check(Vector3Int position)
	{
		return container.Get(position) != null;
	}

	public void Plow(Vector3Int position)
	{
		if(Check(position) == true)
		{
			return;
		}
		CreatePlowedTile(position);
	}
	public void Seed(Vector3Int position, Crop toSeed)
	{
		CropsTile tile = container.Get(position);
		if(tile == null)
		{
			return; 
		}
 
		targetTileMap.SetTile(position, seeded);
		tile.crop = toSeed;
	}

	public void VisualizeTile(CropsTile cropTile)
	{
		targetTileMap.SetTile(cropTile.position, cropTile.crop != null ? seeded : plowed);
		if(cropTile.renderer == null)
		{
			GameObject go = Instantiate(cropsSpritePrefads, transform);
			go.transform.position = targetTileMap.CellToWorld(cropTile.position);
			go.transform.position -= Vector3.forward * 0.01f;
			cropTile.renderer = go.GetComponent<SpriteRenderer>();
		}

		bool growing = cropTile.crop != null && cropTile.growTimer >= cropTile.crop.growthStageTime[0];
		
		cropTile.renderer.gameObject.SetActive(growing);
		if(growing == true)
		{
				cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage-1];
		}
		
	}
	private void CreatePlowedTile(Vector3Int position)
	{
		CropsTile crop = new CropsTile();
		container.Add(crop);

		
		crop.position = position;
		VisualizeTile(crop);

		targetTileMap.SetTile(position, plowed);

	}
	internal void PickUp(Vector3Int gridPosition)
	{
		Vector2Int position = (Vector2Int)gridPosition;
		CropsTile tile = container.Get(gridPosition);
		if(tile == null) { return; }
		if (tile.Complete)
		{
			ItemSpawnManager.instance.SpawnItem(
				targetTileMap.CellToWorld(gridPosition),
				tile.crop.yeild,
				tile.crop.count);
			
			tile.Harvested();
			VisualizeTile(tile);
		}
	}
}
