using UnityEngine;

public class MouseItem : MonoBehaviour
{
    public GameObject currentItem;      //store current dragging item

    //Try to solve the problem of UI occlusion event triggering, find a solution but it is out of scope, so comment it out.
    // Update is called once per frame
    //void Update()
    //{
    //Debug.Log(currentItem.name);
    //if (currentItem != null)
    //{
    //    currentItem.transform.position = Input.mousePosition;

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        DragItem drag = currentItem.GetComponent<DragItem>();
    //        if (drag != null)
    //        {
    //            drag.StartCoroutine("CheckDropTarget");
    //        }

    //        currentItem = null;
    //    }
    //}
    //else
    //{
    //    // ����� plate ��ʼ�����϶�
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        PointerEventData pointerData = new PointerEventData(EventSystem.current)
    //        {
    //            position = Input.mousePosition
    //        };

    //        List<RaycastResult> results = new List<RaycastResult>();
    //        EventSystem.current.RaycastAll(pointerData, results);

    //        foreach (RaycastResult result in results)
    //        {
    //            GameObject target = result.gameObject;
    //            Debug.Log("Click check under mouse: " + target.name);

    //            if (target.name.ToLower().Contains("plate"))
    //            {
    //                PlatingAreaScript plating = FindObjectOfType<PlatingAreaScript>();
    //                if (plating != null)
    //                {
    //                    plating.BeginGroupPickup();
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //}
    //}
}
