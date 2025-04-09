using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    bool isDraggable = true;     //when mouse down and instantiate a prefab, it's draggable
    public bool wasDropped = false;

    // Update is called once per frame
    void Update()
    {
        if (isDraggable)
        {
            transform.position = Input.mousePosition;       //prefab follows mouse
            if (Input.GetMouseButtonUp(0))      //if mouse up, current item isn't draggable, won't follow mouse
            {
                isDraggable = false;
            }
        }

        if (!wasDropped && !isDraggable)
        {
            Debug.Log("test mid");
            Destroy(gameObject);
        }
    }
}
