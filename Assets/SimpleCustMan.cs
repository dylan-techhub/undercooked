using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCustMan : MonoBehaviour
{
    public GameObject customer;
    public CustomerOrderInvUI ui;

    // Start is called before the first frame update
    void Start()
    {
        // get a ref to the order on the gameObject 
        CustomerOrder co = customer.GetComponent<CustomerOrder>();
        ui.inv = co;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
