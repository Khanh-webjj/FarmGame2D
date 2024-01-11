using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tradding : MonoBehaviour
{
    Store store;

    public void BeginTrading(Store store)
	{
		this.store = store;
		Debug.Log("Trad");
		
		
	}
}
