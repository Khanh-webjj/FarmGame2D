using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    [SerializeField] private Transform target;

    Vector3 camOffset;

    void Start()
    {
        if (instance != null  &&  instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
        GameObject.DontDestroyOnLoad(this.gameObject);
        camOffset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        transform.position = target.position + camOffset;
    }
}
