using System.Collections;
using UnityEngine;

//Added to prefab
public class DragItem : MonoBehaviour
{
    bool isDraggable = true;     //when mouse down and instantiate a prefab, it's draggable
    public bool wasDropped = false;     //if it was dropped to the droppable place
    public RectTransform pattyGrillRect;        //store position where can drop item
    public RectTransform bunGrillRect;
    public RectTransform trashcanRect;
    public RectTransform platingAreaRect;
    public PlatingAreaScript platingArea;

    // Update is called once per frame
    void Update()
    {
        if (isDraggable)
        {
            transform.position = Input.mousePosition;       //prefab follows mouse
            //Debug.Log(transform.position);
            if (Input.GetMouseButtonUp(0))      //if mouse up, current item become not draggable, won't follow mouse
            {
                isDraggable = false;
                CookState cookState = GetComponent<CookState>();

                if (cookState != null && cookState.isCooking)       //if drop the cooking item, clear the corresponding grill slot.
                {
                    Debug.Log("cook state is cooking");
                    cookState.StopCook();
                    cookState.ReleaseFromGrill();
                    //if (cookState.pattyGrill != null && cookState.slotIndex != -1)
                    //{
                    //    Debug.Log("clear corresponding slot in patty grill");
                    //    cookState.pattyGrill.pattyInSlot[cookState.slotIndex] = null;
                    //    cookState.pattyGrill.slotUsed[cookState.slotIndex] = false;
                    //}
                    //else if (cookState.bunGrill != null && cookState.slotIndex != -1)
                    //{
                    //    Debug.Log("clear corresponding slot in bun grill");
                    //    cookState.bunGrill.bunInSlot[cookState.slotIndex] = null;
                    //    cookState.bunGrill.slotUsed[cookState.slotIndex] = false;
                    //}
                }

                StartCoroutine(CheckDropTarget());      //check where is dropped
            }
        }

        if (!wasDropped && !isDraggable)        //destroy when is dropped and not at correct position
        {
            Debug.Log("wrong place, destroy");
            Destroy(gameObject);
        }

        IEnumerator CheckDropTarget()
        {
            yield return null;

            Vector3 mousePos = Input.mousePosition;

            //used to check where the item was dropped
            if (RectTransformUtility.RectangleContainsScreenPoint(pattyGrillRect, mousePos) || RectTransformUtility.RectangleContainsScreenPoint(bunGrillRect, mousePos))
            {
                Debug.Log("Over patty grill? " + RectTransformUtility.RectangleContainsScreenPoint(pattyGrillRect, Input.mousePosition));
                GetComponent<CookState>().ResumeOnGrill();
                wasDropped = true;
            }
            else if (RectTransformUtility.RectangleContainsScreenPoint(trashcanRect, mousePos))
            {
                Debug.Log("Over transcan? " + RectTransformUtility.RectangleContainsScreenPoint(trashcanRect, Input.mousePosition));
                Destroy(gameObject);
            }

            if (RectTransformUtility.RectangleContainsScreenPoint(platingAreaRect, mousePos))
            {
                Debug.Log("Over plating area? " + RectTransformUtility.RectangleContainsScreenPoint(platingAreaRect, Input.mousePosition));
                if (platingArea != null && platingArea.TryAddIngredient(gameObject))
                {
                    Debug.Log("platingArea");
                    wasDropped = true;
                    yield break;
                }
            }
            //yield return null;
        }
    }
}
