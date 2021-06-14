using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkSpillStuff : MonoBehaviour {
    //public BoxCollider2D collider;
    public Animator animator;
    private int stage = 0;
    private bool debounce = false;

    public AudioClip open;
    public AudioClip spill;
    public AudioClip clean;
    public AudioSource playAudio;

    public GameObject drinkZone;
    public GameObject spillZone;

    //private void OnCollisionEnter2D(Collision2D collision)
    //public void OnTriggerEnter2D(Collider2D collision) {

    public void ActivateDrink(){


        if (stage == 0 & debounce == false) {
            StartCoroutine(openDrink()); 
        }else if (stage == 1 & debounce == false) {

            drinkZone.SetActive(false);
            spillZone.SetActive(true);

            StartCoroutine(spillDrink());
        }else if (stage == 2 & debounce == false) {
            StartCoroutine(cleanUpDrink());
        }

    }

    IEnumerator openDrink() {

        playAudio.clip = open;
        playAudio.Play();

        animator.SetTrigger("open");
        yield return new WaitForSeconds(1);
        stage = 1;
    }
    IEnumerator spillDrink() {

        playAudio.clip = spill;
        playAudio.Play();

        animator.SetTrigger("spill");
        yield return new WaitForSeconds(1);
        stage = 2;
    }
    IEnumerator cleanUpDrink() {

        playAudio.clip = clean;
        playAudio.Play();

        animator.SetTrigger("clean");
        yield return new WaitForSeconds(1);
        stage = 3;
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }

}