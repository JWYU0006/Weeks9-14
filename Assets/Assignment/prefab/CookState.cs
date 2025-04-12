using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Added to prefab
public class CookState : MonoBehaviour
{
    Image image;            //The Image component to update the food sprite
    public Sprite raw;      //Different states of food visuals
    public Sprite cooked;
    public Sprite burnt;

    public PattyGrillScript pattyGrill;     //Reference to gril
    public BunGrill bunGrill;

    public int slotIndex = -1;      //Slot index on the grill
    public float cookTime = 0;      //Time spent cooking
    Coroutine cookingRoutine;          //Reference to cooking coroutine

    //Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    //Called when ingredient is placed on grill
    public void ResumeOnGrill()
    {
        if (pattyGrill != null)
        {
            pattyGrill.AddToSlot(gameObject);
        }
        else if (bunGrill != null)
        {
            bunGrill.AddToSlot(gameObject);
        }

        // Start cooking
        if (cookingRoutine == null)
        {
            cookingRoutine = StartCoroutine(CookProgress());
        }
    }

    // Stop cooking (e.g. when removed from grill)
    public void StopCook()
    {
        if (cookingRoutine != null)
        {
            StopCoroutine(cookingRoutine);
            cookingRoutine = null;
        }
    }

    // Release slot on grill
    public void ReleaseFromGrill()
    {
        if (slotIndex == -1) return;

        if (pattyGrill != null)
        {
            pattyGrill.RemoveFromSlot(slotIndex);
            //pattyGrill.pattyInSlot[slotIndex] = null;
            //pattyGrill.slotUsed[slotIndex] = false;
        }
        else if (bunGrill != null)
        {
            bunGrill.RemoveFromSlot(slotIndex);
            //bunGrill.bunInSlot[slotIndex] = null;
            //bunGrill.slotUsed[slotIndex] = false;
        }

        slotIndex = -1;
    }

    IEnumerator CookProgress()
    {
        cookTime = 0;
        yield return new WaitForSeconds(0.5f);      // short delay before enabling drag
        // Enable dragging after placed
        //DragItem drag = GetComponent<DragItem>();
        //if (drag != null)
        //{
        //    drag.isDraggable = true;
        //}
        // Start cooking
        while (cookTime <= 16)
        {
            cookTime += Time.deltaTime;
            // Update sprite depending on cook time
            if (cookTime >= 15)
            {
                image.sprite = burnt;
            }
            else if (cookTime >= 10)
            {
                image.sprite = cooked;
                //delete initial designed features, move to plating area automatically.
                // If cooked and not already dropped, auto-send to plating area
                PlatingAreaScript plating = FindObjectOfType<PlatingAreaScript>();
                if (plating != null && plating.TryAddIngredient(gameObject))
                {
                    Debug.Log("Auto moved to plating area.");
                    yield break;
                }
            }
            else
            {
                image.sprite = raw;
            }
            yield return null;
        }
    }
}
