using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//Added to prefab
public class DragItem : MonoBehaviour
{
    public bool isDraggable = true;     //when mouse down and instantiate a prefab, it's draggable
    public bool wasDropped = false;     //if it was dropped to the droppable place
    public Canvas canvas;

    public UnityEvent OnClick;

    public RectTransform pattyGrillRect;        //store position where can drop item
    public RectTransform bunGrillRect;
    public RectTransform trashcanRect;
    public RectTransform platingAreaRect;
    public PattyGrillScript pattyGrill;
    public BunGrill bunGrill;
    public PlatingAreaScript platingArea;
    public bool isFromPlatingArea = false;

    //// This function should be called from a EventTrigger
    public void HandleClick()
    {
        OnClick.Invoke();
    }

    public void PickUpFromGrill()
    {
        CookState cookState = GetComponent<CookState>();
        if (cookState == null || cookState.slotIndex == -1)
        {
            Debug.Log("return pick");
            return;
        }

        cookState.StopCook();
        cookState.ReleaseFromGrill();

        StartCoroutine(SetMouseItemNextFrame());
        transform.SetParent(canvas.transform);
        wasDropped = false;

        Debug.Log("Picked up from grill (click)");
    }

    IEnumerator SetMouseItemNextFrame()
    {
        yield return null;

        MouseItem mouse = FindObjectOfType<MouseItem>();
        if (mouse != null)
        {
            mouse.currentItem = gameObject;
            Debug.Log("Delayed Set currentItem: " + gameObject.name);
        }
    }

    public void ClickMoveToPlatingArea()
    {
        if (platingArea != null)
        {
            platingArea.TryAddIngredient(gameObject);
        }
    }

    //IEnumerator CheckDropTarget()
    //{
    //    Vector2 mousePos = Input.mousePosition;

    //    //used to check where the item was dropped
    //    if (RectTransformUtility.RectangleContainsScreenPoint(pattyGrillRect, mousePos) || RectTransformUtility.RectangleContainsScreenPoint(bunGrillRect, mousePos))
    //    {
    //        Debug.Log("Over patty grill? " + RectTransformUtility.RectangleContainsScreenPoint(pattyGrillRect, Input.mousePosition));
    //        Debug.Log("Over bun grill? " + RectTransformUtility.RectangleContainsScreenPoint(bunGrillRect, Input.mousePosition));
    //        GetComponent<CookState>().ResumeOnGrill();
    //        wasDropped = true;
    //    }
    //    else if (RectTransformUtility.RectangleContainsScreenPoint(trashcanRect, mousePos))
    //    {
    //        Debug.Log("Over transcan? " + RectTransformUtility.RectangleContainsScreenPoint(trashcanRect, Input.mousePosition));
    //        Destroy(gameObject);
    //    }
    //    else if (RectTransformUtility.RectangleContainsScreenPoint(platingAreaRect, mousePos, Camera.main))
    //    {
    //        Debug.Log("Over plating area? " + RectTransformUtility.RectangleContainsScreenPoint(platingAreaRect, Input.mousePosition, Camera.main));
    //        if (platingArea != null && platingArea.TryAddIngredient(gameObject))
    //        {
    //            Debug.Log("platingArea");
    //            wasDropped = true;
    //            yield break;
    //        }
    //    }
    //}

    IEnumerator CheckDropTarget()
    {
        yield break;
        //PointerEventData pointerData = new PointerEventData(EventSystem.current)
        //{
        //    position = Input.mousePosition
        //};

        //List<RaycastResult> results = new List<RaycastResult>();
        //EventSystem.current.RaycastAll(pointerData, results);

        //GameObject underMouse = null;

        //foreach (RaycastResult result in results)
        //{
        //    GameObject target = result.gameObject;
        //    underMouse = target;
        //    Debug.Log("UI under mouse: " + target.name);

        //    // --- Plating Area ---
        //    if (platingArea != null && (target == platingArea.gameObject || target.transform.IsChildOf(platingArea.transform)))
        //    {
        //        if (platingArea.TryAddIngredient(gameObject))
        //        {
        //            Debug.Log("Dropped into Plating Area");
        //            wasDropped = true;
        //            yield break;
        //        }
        //    }

        //    // --- Patty Grill ---
        //    if (pattyGrill != null && (target == pattyGrill.gameObject || target.transform.IsChildOf(pattyGrill.transform)))
        //    {
        //        if (name.ToLower().Contains("patty"))
        //        {
        //            if (pattyGrill.AddToSlot(gameObject))
        //            {
        //                Debug.Log("Dropped onto Patty Grill");
        //                wasDropped = true;
        //                yield break;
        //            }
        //        }
        //    }

        //    // --- Bun Grill ---
        //    if (bunGrill != null && (target == bunGrill.gameObject || target.transform.IsChildOf(bunGrill.transform)))
        //    {
        //        if (name.ToLower().Contains("bun"))
        //        {
        //            if (bunGrill.AddToSlot(gameObject))
        //            {
        //                Debug.Log("Dropped onto Bun Grill");
        //                wasDropped = true;
        //                yield break;
        //            }
        //        }
        //    }

        //    // --- Trashcan ---
        //    if (trashcanRect != null && (target == trashcanRect.gameObject || target.transform.IsChildOf(trashcanRect.transform)))
        //    {
        //        Debug.Log("Dropped into trashcan. Destroyed.");
        //        PlatingAreaScript plating = FindObjectOfType<PlatingAreaScript>();
        //        if (plating != null)
        //        {
        //            plating.RemoveIngredient(gameObject);
        //        }
        //        Destroy(gameObject);
        //        yield break;
        //    }
        //}

        ////没有成功放置
        //if (isFromPlatingArea)
        //{
        //    Debug.Log("No valid drop zone matched, returning to plating area.");
        //    transform.position = platingAreaRect.position;
        //    transform.SetParent(FindObjectOfType<PlatingAreaScript>().transform);
        //    wasDropped = true;
        //    yield break;
        //}
        //else
        //{
        //    Debug.Log("No valid drop zone matched. Destroying.");
        //    Destroy(gameObject);
        //}
    }
}
