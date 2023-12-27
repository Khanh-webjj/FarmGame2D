using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

<<<<<<< HEAD
    [SerializeField] public GameObject highlight;
=======
    [SerializeField] private GameObject highlight;
>>>>>>> 622393fc2c79c57077e4ae78979d49ed5f7787ff

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1,1,1,1);
            quantityText.text = slot.count.ToString();
        }
    }

    public void SetEmpty ()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }

<<<<<<< HEAD
    public void SetHighlight(bool isOn)
    {
=======
    public void SetHighlight(bool isOn) {
>>>>>>> 622393fc2c79c57077e4ae78979d49ed5f7787ff
        highlight.SetActive(isOn);
    }
}
