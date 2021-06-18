using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringUI : MonoBehaviour
{
    // Counters in UI, set them by assigning a String (or int converted to String) to the .text variable
    public Text customersTotalText;
    public Text customerNumText;
    public Text avgTimeText;
    public Text currentTimeText;
    public Text scoreText;

    // Customer manager
    public CustomerOrder inv;

    // variables to store
    public int totalCustomers = 0;
    public int currentCustomer = 0;
    public int avgTime = 0; // how do we keep this accurate? Tricky problem here. 
    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Assign to the Text UI elements
        customerNumText.text = "" + currentCustomer;
        avgTimeText.text = "" + avgTime;
        currentTimeText.text = "" + 0;
        scoreText.text = "" + 0;

        // Set the total number of customers at the beginning of the level
        //customersTotalText.text = "" + totalCustomers;
    }

    private void Update()
    {
        customerNumText.text = "" + currentCustomer;
        avgTimeText.text = "" + avgTime;
        //currentTimeText.text = "" + 0;
        currentTimeText.text = "" + (int)inv.timeSinceOrderTaken;

        // This is put in update because I know it will work here, but I'm not 100% sure it would work in Start()
        customersTotalText.text = "" + totalCustomers;
    }

    // Call every frame in Update method
    public void UpdateOrderTimer(int currentTimer){
        currentTimeText.text = "" + currentTimer;
    }

    public void OrderCompleted(float timeItTook){
        // convert to int

        // add to average (a little tricky, normalize over the proportion it will contribute
    }

    public void addScoreToUI()
    {
        Debug.Log("ADDING SCOREEEE");
        if (inv.timeSinceOrderTaken <= 40)
        {
            score += 100;
            scoreText.text = "" + score;
        }
        else
        {
            score += 75;
            scoreText.text = "" + score;
        }
    }

}
