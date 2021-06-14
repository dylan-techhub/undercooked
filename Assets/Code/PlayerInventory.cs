using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    // Variables
    public bool hasPizza = false;
    public int burgers;
    public int drinks;
    public int deluxeBurger = 0;
    public bool hasTrash = false;
    public bool hasMop = false;
    public bool hasRestockBox = false;

    public UnityEvent handsAreFull = new UnityEvent();
    public UnityEvent trashDiscarded = new UnityEvent();

    public void RemoveAll() // removes all
    {
        drinks = 0;
        burgers = 0;
        deluxeBurger = 0;
        hasPizza = false;
    }

    public int ConvertToint()
    { // poggers code
        if (hasPizza)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public int CountItems()
    {
        return (burgers + drinks + deluxeBurger + ConvertToint());
    }

    public bool RemoveTrash()
    {

        if (hasTrash)
        {
            hasTrash = false;
            return true;
        }
        else
        {
            Debug.Log("No Trash to remove");
            return false;
        }
    }

    public bool AddTrash()
    {
        if (hasPizza || burgers > 0 || drinks > 0 || deluxeBurger > 0 || hasMop)
        {
            Debug.Log("Can't pick up trash while my hands are full");
            return false;
        }
        else
        {
            Debug.Log("Picked Up Trash");
            hasTrash = true;
            return true;
        }
    }


    // Garbage Chute
    public void DumpAllInventory(){
        hasPizza = false;
        burgers = 0;
        drinks = 0;
        deluxeBurger = 0;
        hasTrash = false;
        hasMop = false;
        hasRestockBox = false;
    }

    // trash Can
    public void ThrowInTrash(){
        hasPizza = false;
        burgers = 0;
        drinks = 0;
        deluxeBurger = 0;
        hasMop = false;
        hasRestockBox = false;
    }

    public bool PickUpTrash(){
        if(hasFullSlot()){
            hasTrash = true;
            return true;
        }else{
            return false;
        }
    }

    // For Mop/Restock/pizza/trash
    public bool hasFullSlot(){
        if(hasPizza || burgers > 0 || drinks > 0 || deluxeBurger > 0 || hasTrash || hasRestockBox || hasMop){
            handsAreFull.Invoke();
            return false;
        }else{
            return true;
        }

        // This code could also be simplified to this:
        //return !(hasPizza || burgers > 0 || drinks > 0 || deluxeBurger > 0 || hasTrash || hasRestockBox || hasMop);
    }

    // If we have room for a single unit item, which we cna hold 3 of
    public bool hasOneSpot() {
        int singleItemCount = burgers + drinks + deluxeBurger;

        if (hasPizza || singleItemCount > 2 || hasTrash || hasRestockBox || hasMop){
            handsAreFull.Invoke();
            return false;
        }else{
            return true;
        }
    }

    public void AddMop() {

        if (hasFullSlot())
        {
            Debug.Log("Picked Up Mop");
            hasMop = true;
        } else
        {
            Debug.Log("Can't pick up mop while my hands are full");
        }

    }

    public void RemoveMop()
    {
        hasMop = false;
    }

    public bool UpgradeBurger() {
        if (burgers > 0) {
            burgers--;
            deluxeBurger++;
            return true;
        } else {
            // no burgers found
            return false;
        }
    }

    // 
    public bool AddPizza()
    {
        if (hasFullSlot())
        {
            hasPizza = true;
            return true;
        } else
        {
            Debug.Log("Can't pick up a pizza with a burger in your hand");
            return false;
        }
    }

    public bool HasPizza()
    {
        return hasPizza;
    }

    public bool RemovePizza()
    {

        if (hasPizza)
        {
            hasPizza = false;
            return true;
        }
        else
        {
            Debug.Log("No Pizza to remove");
            return false;
        }
    }
    public bool AddRestockBox()
    {
        if (hasFullSlot())
        {

            Debug.Log("Picked up RestockBox");
            hasRestockBox = true;
            return true;
        }
        else
        {
            Debug.Log("Can't pick up RestockBox with stuff in your inventory");
            return false;
        }
    }
    public void RemoveRestockBox()
    {
        hasRestockBox = false;
    }

    // Methods
    // Adding a burger to the Inventory
    public bool AddBurger()
    {
        // first enter your pin number
        // Statement within the method
        if(hasOneSpot())
        {

            Debug.Log("Added a burger");
            burgers++;
            return true;
        }
        else
        {
            // We are full and can't take the burger. 
            return false;
        }
        
       
        // Update the UI
        // Play sound effect
        // update the art
        // 
    }

    // Accessor
    // () parameter list
    //{ begin method
    // } end method
    public bool HasBurger() // Unused method
    {
        return (burgers > 0);
        /*
        if(burgers > 0){
            return true;
        }else{
            return false;
        }*/
    }

    public bool RemoveBurger()
    {
        if(burgers > 0)
        {
            burgers--;
            Debug.Log("Burger Removed");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddDrink()
    {
        // first enter your pin number
        // Statement within the method
        if (hasOneSpot())
        {
            // We are full and can't take the drink. 
            Debug.Log("Added a drink");
            drinks++;
            return true;
        }
        else
        {
            return false;
        }

        
        // Update the UI
        // Play sound effect
        // update the art
        // 
    }

    public bool HasDeluxeBurger() // Unused method
    {
        return (deluxeBurger > 0);
    }

    public bool RemoveDeluxeBurger() {
        if (deluxeBurger > 0) {
            deluxeBurger--;
            Debug.Log("Deluxe Burger Removed");
            return true;
        } else {
            return false;
        }
    }

    public bool RemoveDrink()
    {
        if (drinks > 0)
        {
            drinks--;
            Debug.Log("Drink Removed");
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
    // Coding samples
    public void ContrivedExample(){
        int c = AddNums(3, 4); // 7

        int d = AddNums(7, 8);

        int e = AddNums(8, 9);
    }

    public int AddNums(int a, int b){
        int sum = a + b;
        Debug.Log(sum + " " + a + " + " + b);
        return a + b;
    }
    */
}
