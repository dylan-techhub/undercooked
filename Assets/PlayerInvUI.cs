using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInvUI : MonoBehaviour
{
    /*  PlayerInventory
     *     // Variables
    public bool hasPizza = false;
    public int burgers;
    public int drinks;
    public int deluxeBurger = 0;
    public bool hasTrash = false;
    public bool hasMop = false;

    */
    [Header("Inventory Reference")]
    public PlayerInventory inv;

    [Header("Inventory Icons")]
    public GameObject mopIcon;
    public GameObject pizzaIcon;
    public GameObject trashIcon;
    public GameObject burgerIcon;
    public Text burgerCountText;
    public GameObject deluxeBurgerIcon;
    public Text deluxeBurgerCountText;
    public GameObject drinkIcon;
    public Text drinkCountText;

    public GameObject restockBoxIcon;

//    [Header("Player Feedback")]
//    public Text messagesToPlayer;

    public void Update(){
        // Mop
        mopIcon.SetActive(inv.hasMop);
        // Pizza
        pizzaIcon.SetActive(inv.hasPizza);
        // Trash 
        trashIcon.SetActive(inv.hasTrash);
        // Burgers
        burgerIcon.SetActive(inv.burgers > 0);
        burgerCountText.text = "" + inv.burgers;
        // Deluxe Burger
        deluxeBurgerIcon.SetActive(inv.deluxeBurger > 0);
        deluxeBurgerCountText.text = "" + inv.deluxeBurger;
        // Drinks
        drinkIcon.SetActive(inv.drinks > 0);
        drinkCountText.text = "" + inv.drinks;

        restockBoxIcon.SetActive(inv.hasRestockBox);

    }
}
