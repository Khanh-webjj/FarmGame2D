using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    bool isTrigger = false;
    void Update() {
        if (isTrigger) {
            if(Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("We just move scene");
                switch(SceneManager.GetActiveScene().buildIndex) {
                    case 1: 
                        SceneManager.LoadScene(3);
                        break;
                    case 3: 
                        SceneManager.LoadScene(1);
                        break;
                }
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D) {
        Debug.Log("We just collided");
        isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collider2D) {
        Debug.Log("We done collided");
        isTrigger = false;
    }
}
