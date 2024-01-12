using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepawn : MonoBehaviour
{

    [SerializeField] Vector3 respawnPointPosition;
    [SerializeField] string respawnPointScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	internal void StartRespawn()
	{
        GameSceneManager.instance.Respawn(respawnPointPosition, respawnPointScene);
	}
}
