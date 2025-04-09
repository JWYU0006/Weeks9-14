using System.Collections;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    bool isDraggable = true;     //when mouse down and instantiate a prefab, it's draggable
    public bool wasDropped = false;
    public RectTransform pattyGrillRect;
    public RectTransform bunGrillRect;
    public RectTransform trashcanRect;
    public RectTransform platingAreaRect;

    // Update is called once per frame
    void Update()
    {
        if (isDraggable)
        {
            transform.position = Input.mousePosition;       //prefab follows mouse
            if (Input.GetMouseButtonUp(0))      //if mouse up, current item isn't draggable, won't follow mouse
            {
                isDraggable = false;
                CookState cookState = GetComponent<CookState>();
                if (cookState != null && cookState.isCooking)
                {
                    cookState.StopCook();
                    if (cookState.pattyGrill != null && cookState.slotIndex != -1)
                    {
                        cookState.pattyGrill.pattyInSlot[cookState.slotIndex] = null;
                        cookState.pattyGrill.slotUsed[cookState.slotIndex] = false;
                    }
                    else if (cookState.bunGrill != null && cookState.slotIndex != -1)
                    {
                        cookState.bunGrill.bunInSlot[cookState.slotIndex] = null;
                        cookState.bunGrill.slotUsed[cookState.slotIndex] = false;
                    }
                }
                StartCoroutine(CheckDropTarget());
            }
        }

        if (!wasDropped && !isDraggable)
        {
            Debug.Log("test mid");
            Destroy(gameObject);
        }

        IEnumerator CheckDropTarget()
        {
            yield return null;

            Vector3 mousePos = Input.mousePosition;

            if (RectTransformUtility.RectangleContainsScreenPoint(pattyGrillRect, mousePos) || RectTransformUtility.RectangleContainsScreenPoint(bunGrillRect, mousePos))
            {
                GetComponent<CookState>().ResumeOnGrill();
                wasDropped = true;
            }
            else if (RectTransformUtility.RectangleContainsScreenPoint(trashcanRect, mousePos))
            {
                Destroy(gameObject);
            }
        }
    }
}
