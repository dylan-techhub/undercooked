using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringUI : MonoBehaviour
{
    // Counters in UI, set them by assigning a String (or int converted to String) to the .text variable
    public Text customerNumText;
    public Text avgTimeText;
    public Text currentTimeText;

    // Customer manager
    public CustomerOrder inv;

    // variables to store
    public int currentCustomer = 0;
    public int avgTime = 0; // how do we keep this accurate? Tricky problem here. 


    // Start is called before the first frame update
    void Start()
    {
        // Assign to the Text UI elements
        customerNumText.text = "" + currentCustomer;
        avgTimeText.text = "" + avgTime;
        currentTimeText.text = "" + 0;

    }

    private void Update()
    {
        customerNumText.text = "" + currentCustomer;
        avgTimeText.text = "" + avgTime;
        //currentTimeText.text = "" + 0;
        currentTimeText.text = "" + (int)inv.timeSinceOrderTaken;
    }

    // Call every frame in Update method
    public void UpdateOrderTimer(int currentTimer){
        currentTimeText.text = "" + currentTimer;
    }

    public void OrderCompleted(float timeItTook){
        // convert to int

        // add to average (a little tricky, normalize over the proportion it will contribute

    }

}
