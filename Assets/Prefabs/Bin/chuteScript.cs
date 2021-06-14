using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuteScript : MonoBehaviour
{
    public BoxCollider2D collider;
    public SpriteRenderer sprite;
    public Sprite closed;
    public Sprite open;
    public trashScript trashScript;
    private bool isPlayerNearby = false;
    public PlayerInventory inv;

    // Start is called before the first frame update
    void Update()
    {
        if (isPlayerNearby)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (inv.hasTrash == true)
                {
                    UseChute();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPlayerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerNearby = false;
    }

    public void UseChute()
    {
        inv.RemoveTrash();
        sprite.sprite = closed;
    }

    public void openChute()
    {
        sprite.sprite = open;
    }
}
