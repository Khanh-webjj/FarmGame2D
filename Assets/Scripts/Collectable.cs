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


    override
    public string ToString()
    {
        string type = "";
        switch (this.type) 
        {
            case CollectableType.NONE:
                {
                    type = "NONE";
                    break;
                }
            case CollectableType.CARROT_SEED:
                {
                    type = "CARROT_SEED";
                    break;
                }
            case CollectableType.POTATO_SEED:
                {
                    type = "POTATO_SEED";
                    break;
                }
            case CollectableType.EGG:
                {
                    type = "EGG";
                    break;
                }
        }

        return "type: " + type;
    }
}

public enum CollectableType
{
    NONE, CARROT_SEED, POTATO_SEED, EGG
}
