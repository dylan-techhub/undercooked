using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    // Editor Variables
    /*   public GameObject customer1;
       public CustomerMovement cus1;
       public GameObject customer2;
       public CustomerMovement cus2;
       public GameObject customer3;
       public CustomerMovement cus3;
       public GameObject customer4;
       public CustomerMovement cus4;
       public GameObject customer5;
       public CustomerMovement cus5;
       public GameObject customer6;
       public CustomerMovement cus6;
   */
    public GameObject[] customers;
    public CustomerMovement[] movement;

    public PlayerInventory inv;

    public CustomerOrderInvUI invUI;

    public ScoringUI scoreUI;

    // Unused.
    //public int playerScore;

    // Game over screen to pop up
    public GameObject gameOver;

    // Private Variables
    private int customerIndex = 0;

    public float leaveTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // Bring in the first customer
        NextCustomerEnter();

        // Set the ScoringUI.totalCustomers to the lenght of the customers list
        scoreUI.totalCustomers = customers.Length;
    }

    // how long it took, etc
    public void OrderComplete(){
        NextCustomerExit();
        NextCustomerEnter();
    }

    // Make the next customer enter
    public void NextCustomerEnter()
    {
        customers[customerIndex].SetActive(true);
        movement[customerIndex].WalkIn();
        // UI ref
        CustomerOrder order = customers[customerIndex].GetComponent<CustomerOrder>();

        invUI.inv = order; // For the inventory UI

        scoreUI.currentCustomer = customerIndex; // For the score UI
        scoreUI.inv = order; // For the score UI
                             //scoreUI.

       
    }

    public void NextCustomerExit() {
        // Run the addScoreToUI() in the ScoringUI gameobject.
        scoreUI.addScoreToUI();
        
        // Move the customer
        movement[customerIndex].WalkOut();
        StartCoroutine(NextCustomerExitTimer(customers[customerIndex]));

        // Activate the customer
        customerIndex++;
        if (customerIndex >= customers.Length) {
            customerIndex = 0;
            // Game over!
            endscreen();
        }

    }
    
    // IEnumerator lets us use a co-routine, which lets us use a timer
    private IEnumerator NextCustomerExitTimer(GameObject cust){

        // do exit stuff

        yield return new WaitForSeconds(leaveTime);

        cust.SetActive(false);
    }

    private void endscreen()
    {
        gameOver.SetActive(true);
    }
}
