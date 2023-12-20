using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(21);
    }

    public void DropItem(Collectable item)
    {
        Vector3 spawnLocation = transform.position;

        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);

        Vector3 spawnOffset = new Vector3(randX, randY, 0f).normalized;

        Collectable dropedItem = 
            Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        dropedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    }
}
