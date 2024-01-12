using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolBarPanel : ItemPanel
{
	[SerializeField] ToolBarController toolBarController;
	private void Start()
	{
		Init();
		toolBarController.onChange += HightLight;
		HightLight(0);
	}
	public override void OnClick(int id)
	{
		toolBarController.Set(id);
		HightLight(id);
	}
	int currentSelectedTool;
	public void HightLight(int id)
	{
		buttons[currentSelectedTool].HightLight(false);
		currentSelectedTool = id;
		buttons[currentSelectedTool].HightLight(true);
	}
	public override void Show()
	{
		base.Show();
		toolBarController.UpdateHightLightIcon();
	}
}
