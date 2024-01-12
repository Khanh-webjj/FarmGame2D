using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Interactable
{
	public override void Interact(Character character)
	{
		Tradding tradding = character.GetComponent<Tradding>();
		if(tradding == null)
		{
			return;
		}
		tradding.BeginTrading(this);
	}
}
