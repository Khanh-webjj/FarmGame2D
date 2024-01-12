using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Crops Container")]
public class CropContainer : ScriptableObject
{
	public List< CropsTile> crops;
	public CropsTile Get(Vector3Int position)
	{
		return crops.Find(x => x.position == position);
	}

	public void Add(CropsTile crop)
	{
		crops.Add(crop);
	}
}
