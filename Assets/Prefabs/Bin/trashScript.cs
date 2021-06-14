using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashScript : MonoBehaviour
{
    // Editor Varaibles
    public SpriteRenderer trashBinSprite;
    public BoxCollider2D collider;
    public PlayerInventory inv;
    public chuteScript chute;

    public Sprite emptyTrash;
    public Sprite someTrash;
    public int trashMax = 5;
    public int trashCurrent = 0;

    // Private Variables
    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetButtonDown("Jump"))
        {
            DumpInventoryInTrash();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isPlayerNearby = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isPlayerNearby = false;
    }

    private void DumpInventoryInTrash()
    {
        if (inv.CountItems() > 0)
        {
            Debug.Log("Added " + inv.CountItems() + " items to trashbin");
            trashBinSprite.sprite = someTrash;
            trashCurrent += inv.CountItems();
            inv.RemoveAll();
        }

        // Force the player to remove the trash if the trashbin is full.
        if (trashCurrent >= trashMax)
        {
            RemoveTrash();
            chute.openChute();
            Debug.Log("Trash is at max, automatically giving player trash");
        }
    }

    private void RemoveTrash()
    {
        trashCurrent = 0;
        inv.AddTrash();
        trashBinSprite.sprite = emptyTrash;
    }

}