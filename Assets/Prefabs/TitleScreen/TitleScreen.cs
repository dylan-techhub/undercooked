using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TitleScreen : MonoBehaviour
{
    public UnityEvent GetButtonEvent = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //TitleScreen.SetActive (false) ;
            GetButtonEvent.Invoke();
        }

    }
}
