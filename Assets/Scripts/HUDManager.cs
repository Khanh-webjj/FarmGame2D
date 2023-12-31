using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    // Start is called before the first frame update
    private void Awake() {
        if (instance != null  &&  instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
