using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JSonStringList : ScriptableObject
{
    public List<string> strings;

	internal void SetString(string jsonString, int idInlist)
	{
		if(strings.Count <= idInlist)
		{
			int count = strings.Count - idInlist+1;
			while(count > 0)
			{
				strings.Add("");
				count--;
			}
		}
		strings[idInlist] = jsonString;
	}

	internal string GetString(int idInlist)
	{
		if(idInlist >= strings.Count)
		{
			return "";
		}
		return strings[idInlist];
	}
}
