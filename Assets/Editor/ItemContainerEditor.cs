using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemContainer))]
public class ItemContainnerEditor : Editor
{
	public override void OnInspectorGUI()
	{	
		ItemContainer container = target as ItemContainer;
		if(GUILayout.Button("Cleat Cointainer"))
		{
			for(int i = 0;i < container.slots.Count; i++)
			{
				container.slots[i].Clear();
			}
		}
		DrawDefaultInspector();
	}
}
