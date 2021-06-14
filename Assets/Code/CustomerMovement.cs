using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public float speed = 1f;
    private float moveForce = 0f;

    //private bool wasAtCounter = false;

    //public CustomerManager manager;

    // Editor variables
    public Rigidbody2D rigid;

    /*
    // Walk into the scene
    void Start()
    {
        WalkIn(); //temporary start on play
    }
    */

   // Walk to the counter
    public void WalkIn() 
    {
        Debug.Log("Customer walk in");
        moveForce = 1f;
    }

    // Leave the counter
    public void WalkOut()
    {
        Debug.Log("Customer walk out");
        moveForce = -1f;
       // manager.NextCustomerEnter();
    }

    // Physics update loop, used for adding force to the rigidbody
    private void FixedUpdate()
    {
        rigid.AddForce(new Vector2(speed * moveForce, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only stop moving if the collision has the Counter tag
        if (collision.gameObject.CompareTag("Counter"))
        {
            Debug.Log("Customer is at counter");
            moveForce = 0f;

            rigid.constraints = RigidbodyConstraints2D.FreezePosition;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            //wasAtCounter = true;
        }
    }
}
