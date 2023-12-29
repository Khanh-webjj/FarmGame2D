using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    
    // Player move onto collectable
    // collectable add to Player
    // delete collectable on the screen
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            Item item = GetComponent<Item>();

            if (item != null)
            {
                player.inventory.Add(item);
                Destroy(this.gameObject);
            }
        }
    }

}

