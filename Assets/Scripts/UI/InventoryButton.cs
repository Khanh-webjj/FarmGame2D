
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] Image icon;
	[SerializeField] TextMeshProUGUI text;
	[SerializeField] Image hightlight;
	
	int myindex;
	public void SetIndex(int index)
	{
		myindex = index;
	}
	public void Set(ItemSlot Slot)
	{
		icon.gameObject.SetActive(true);
		icon.sprite = Slot.item.icon;
		if(Slot.item.stackable == true )
		{
			text.gameObject.SetActive(true);
			text.text = Slot.Count.ToString();
		}
		else
		{
			text.gameObject.SetActive (false);
		}
	}
	public void Clean()
	{
		icon.sprite = null;
		icon.gameObject.SetActive(false);

		text.gameObject.SetActive(false );
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
		itemPanel.OnClick(myindex);
	}

	public void HightLight(bool b)
	{
		hightlight.gameObject.SetActive(b);
	}
}
