using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSpriteHack : MonoBehaviour
{
    public SpriteRenderer art;
    public bool isEnabled = true;

    public bool useAlternateTransformForPosition = false;
    public Transform altTransform;

    public bool manualOffset = false;
    public int manualOffsetAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        art = GetComponent<SpriteRenderer>();
        if(art == null){
            Debug.Log("No SpriteRenderer found on " + gameObject.name);
            isEnabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnabled){
            // the 10 is to spread the y float value more evenly across int values (so .2 and .4 are sorted appropriately)
            // the - is because things with a higher y value should be in the back (lower sortingOrder)

            Vector3 pos = Vector3.zero ;
            if (useAlternateTransformForPosition){
                pos = altTransform.position;
            }else{
                pos = transform.position;
            }

            art.sortingOrder = (int)(pos.y*-10);

            if(manualOffset){
                art.sortingOrder += manualOffsetAmount;
            }
        }
    }
}
