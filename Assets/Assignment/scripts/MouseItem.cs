using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseItem : MonoBehaviour
{
    public GameObject currentItem;      //store current dragging item

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentItem.GetComponent<UnityEngine.UI.Image>().raycastTarget);
    }
}
