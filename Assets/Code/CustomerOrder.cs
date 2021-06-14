using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    // Variables
    public int pizzasOrdered;
    public int burgersOrdered;
    public int deluxeBurgersOrdered;
    public int drinksOrdered;

    private int dingBellCount;

    public bool orderTaken = false;
    public float timeSinceOrderTaken = 0f;

    // Editor Variables
    public int minPizzasCanOrder = 0; // Minimum number of pizzas that can be ordered by the customer (inclusive)
    public int minBurgersCanOrder = 0; // Minimum number of burgers that can be ordered by the customer (inclusive)
    public int minDeluxeBurgersCanOrder = 0; // Minimum number of deluxe burgers that can be ordered by the customer (inclusive)
    public int minDrinksCanOrder = 0; // Minimum number of drinks that can be ordered by the customer (inclusive)

    public int maxPizzasCanOrder = 2; // Maximum number of pizzas that can be ordered by the customer (exclusive)
    public int maxBurgersCanOrder = 2; // Maximum number of burgers that can be ordered by the customer (exclusive)
    public int maxDeluxeBurgersCanOrder = 2; // Maximum number of deluxe burgers that can be ordered by the customer (exclusive)
    public int maxDrinksCanOrder = 2; // Maximum number of drinks that can be ordered by the customer (exclusive)

    public AudioClip sfxOrderServedBellSingle; // Bell sound effect for when the customer receives part of the order
    public AudioClip sfxOrderServedBellDouble; // Double Bell sound effect for when the customer receives the whole order
    public AudioClip sfxOrderTakenSound; // Temp sound effect for when the customer's order is taken

    public AudioSource playAudio; // Audio player

    public PlayerInventory inventory;

    //public CustomerMovement movement;
    public CustomerManager man;


    // Update is called once per frame
    void Update()
    {
        // Increase timeSinceOrderTaken if order has been taken
        if (orderTaken)
        {
            timeSinceOrderTaken += Time.deltaTime;
        }
    }
    
    // Take Order
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision has the tag Player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player near customer");
            if (orderTaken == false)
            {
                GenerateNewOrder();
                orderTaken = true;
            }
            else
            {
                ReceiveOrder();
            }
        }
    }


    private void ReceiveOrder()
    {

        if ( (pizzasOrdered > 0) && inventory.RemovePizza() ) // Run RemovePizza() from PlayerInventory.cs on the player
        {
            Debug.Log("1 Pizza given to customer");
            pizzasOrdered--;
            dingBellCount = 1;
        }


        if ( (burgersOrdered > 0) && inventory.RemoveBurger() ) // Run RemoveBurger() from PlayerInventory.cs on the player
        {
            Debug.Log("1 Burger given to customer");
            burgersOrdered--;
            dingBellCount = 1;
        }

        if ( (deluxeBurgersOrdered > 0) && inventory.RemoveDeluxeBurger() ) // Run RemoveDeluxeBurger() from PlayerInventory.cs on the player
        {
            Debug.Log("1 Deluxe Burger given to customer");
            deluxeBurgersOrdered--;
            dingBellCount = 1;
        }

        if ( (drinksOrdered > 0 ) && inventory.RemoveDrink() ) // Run RemoveDrink() from PlayerInventory.cs on the player
        {
            Debug.Log("1 Drink given to customer");
            drinksOrdered--;
            dingBellCount = 1;
        }

        // Check if order is complete
        if ( (pizzasOrdered == 0) && (burgersOrdered == 0) && (deluxeBurgersOrdered == 0) && (drinksOrdered == 0) )
        {
            Debug.Log("Customer order complete");
            dingBellCount = 2;

            // Make the customer walk away with the CustomerMovement script
            //movement.WalkOut();
            man.OrderComplete();
        }

        // Check if the bell needs to be dinged
        if (dingBellCount > 0) 
        {
            if (dingBellCount == 1)
            {
                playAudio.clip = sfxOrderServedBellSingle;
                // Ding Bell Once
                playAudio.Play();
            }
            else
            {
                playAudio.clip = sfxOrderServedBellDouble;
                // Ding Bell Twice
                playAudio.Play();
            }

            dingBellCount = 0; // Set dingBellCount to 0
        }

    }

    private void GenerateNewOrder()
    {
        // Generate the random numbers of each item ordered
        pizzasOrdered = Random.Range(minPizzasCanOrder, maxPizzasCanOrder); // Order a random number of pizzas
        burgersOrdered = Random.Range(minBurgersCanOrder, maxBurgersCanOrder); // Order a random number of burgers
        deluxeBurgersOrdered = Random.Range(minDeluxeBurgersCanOrder, maxDeluxeBurgersCanOrder); // Order a random number of deluxe burgers
        drinksOrdered = Random.Range(minDrinksCanOrder, maxDrinksCanOrder); // Order a random number of drinks


        // Check if the order was completely empty
        if ((pizzasOrdered == 0) && (burgersOrdered == 0) && (deluxeBurgersOrdered == 0) && (drinksOrdered == 0))
        {
            Debug.Log("Warning: Order contained no items. Defaulting to order of one burger. (Make sure the customer orders at least one item!)");
            burgersOrdered = 1;
        }


        Debug.Log("New Order Generated - " + pizzasOrdered + " pizzas, " + burgersOrdered + " burgers, " + deluxeBurgersOrdered + " deluxe burgers, " + drinksOrdered + " drinks");

        playAudio.clip = sfxOrderTakenSound;
        playAudio.Play();

        // Return these variables?
    }
}
