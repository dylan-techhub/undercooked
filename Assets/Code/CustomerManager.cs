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

    public int playerScore;

    // Private Variables
    private int customerIndex = 0;

    public float leaveTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // Bring in the first customer
        NextCustomerEnter();
    }

    // how long it took, etc
    public void OrderComplete(){
        NextCustomerExit();
    }

    // Make the next customer enter
    public void NextCustomerEnter()
    { 
        // Activate the customer
        customers[customerIndex].SetActive(true);
        movement[customerIndex].WalkIn();
        // UI ref
        CustomerOrder order = customers[customerIndex].GetComponent<CustomerOrder>();
        invUI.inv = order;
        customerIndex++;
        if(customerIndex >= customers.Length){
            customerIndex = 0;
        }
    }

    public void NextCustomerExit() {
        movement[customerIndex].WalkOut();
        StartCoroutine(NextCustomerExitTimer(customers[customerIndex]));

    }
    
    // IEnumerator lets us use a co-routine, which lets us use a timer
    private IEnumerator NextCustomerExitTimer(GameObject cust){

        // do exit stuff

        yield return new WaitForSeconds(leaveTime);

        cust.SetActive(false);
    }
}
