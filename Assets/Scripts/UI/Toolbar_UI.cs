using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<Slot_UI> toolbarSlots = new List<Slot_UI>();

    private Slot_UI selectedSlot;

    private void Start()
    {
        SelectSlot(0);
    }

    private void Update()
    {
        CheckAlphaNumericKeys();
    }

    public void SelectSlot(int index)
    {
        if(toolbarSlots.Count == 9)
        {
            if(selectedSlot != null)
            {
=======
public class Toobar_UI : MonoBehaviour
{
    [SerializeField] private List<Slot_UI> toolbarSlots = new List<Slot_UI>();
    
    private Slot_UI selectedSlot;

    private void Start() {
        SelectSlot(0);
    }

    private void Update() {
        CheckAlphaNumericKeys();
    }
    
    public void SelectSlot(int index) {
        if(toolbarSlots.Count == 9) {
            if(selectedSlot != null) {
>>>>>>> 622393fc2c79c57077e4ae78979d49ed5f7787ff
                selectedSlot.SetHighlight(false);
            }

            selectedSlot = toolbarSlots[index];
            selectedSlot.SetHighlight(true);
        }
    }

<<<<<<< HEAD
    private void CheckAlphaNumericKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectSlot(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectSlot(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectSlot(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
=======
    private void CheckAlphaNumericKeys() {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            SelectSlot(0);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            SelectSlot(1);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            SelectSlot(2);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            SelectSlot(3);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            SelectSlot(4);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha6)) {
            SelectSlot(5);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha7)) {
            SelectSlot(6);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha8)) {
            SelectSlot(7);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha9)) {
>>>>>>> 622393fc2c79c57077e4ae78979d49ed5f7787ff
            SelectSlot(8);
        }

    }
}
