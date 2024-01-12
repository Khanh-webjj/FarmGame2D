using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IconHightLight : MonoBehaviour
{
	public Vector3Int cellPosition;
	public Vector3 targetPosition;
	[SerializeField] Tilemap targetTileMap;
	SpriteRenderer spriteRenderer;

	bool canSelect;
	bool show;
	public bool CanSelect
	{
		set
		{
			canSelect = value;
			gameObject.SetActive(canSelect && show);
		}
	}
	public bool Show
	{
		set
		{
			show = value;
			gameObject.SetActive(canSelect && show);
		}
	}
	private void Update()
	{
		targetPosition = targetTileMap.CellToWorld(cellPosition);
		transform.position = targetPosition + targetTileMap.cellSize/2;
	}


	internal void Set(Sprite icon)
	{
		if(spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();

			spriteRenderer.sprite = icon;
		}
	}
}
