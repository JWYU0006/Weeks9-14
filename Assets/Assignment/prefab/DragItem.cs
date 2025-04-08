using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    MouseItem mouseItem;
    bool isDragging = true;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = Input.mousePosition;
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }
    }
}
