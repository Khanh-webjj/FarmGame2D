using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private void Awake()
	{
		Instance = this; 
	}
	public GameObject player;
	public ItemContainer inventoryContainer;
	public ItemDragAndDropController dragAndDropController;
	public DayTimeController timeController;
	public DiaglogueSystem diaglogueSystem;
	public ItemList itemDB;
	public OnScreenMessageSystem messageSystem;
	public ScreenTint screenTint;
}
