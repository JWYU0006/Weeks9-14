using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        //Debug.Log(currentItem.name);
        if (currentItem != null)
        {
            currentItem.transform.position = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                DragItem drag = currentItem.GetComponent<DragItem>();
                if (drag != null)
                {
                    drag.StartCoroutine("CheckDropTarget");
                }

                currentItem = null;
            }
        }
        else
        {
            // 检测点击 plate 开始整组拖动
            if (Input.GetMouseButtonDown(0))
            {
                PointerEventData pointerData = new PointerEventData(EventSystem.current)
                {
                    position = Input.mousePosition
                };

                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, results);

                foreach (RaycastResult result in results)
                {
                    GameObject target = result.gameObject;
                    Debug.Log("Click check under mouse: " + target.name);

                    if (target.name.ToLower().Contains("plate"))
                    {
                        PlatingAreaScript plating = FindObjectOfType<PlatingAreaScript>();
                        if (plating != null)
                        {
                            plating.BeginGroupPickup();
                            break;
                        }
                    }
                }
            }
        }
    }
}
