using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    public Rigidbody2D rb2d;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    } 


    // Player move onto collectable
    // collectable add to Player
    // delete collectable on the screen
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, CARROT_SEED, POTATO_SEED, EGG
}
