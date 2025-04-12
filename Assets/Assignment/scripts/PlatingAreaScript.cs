using System.Collections.Generic;
using UnityEngine;

public class PlatingAreaScript : MonoBehaviour
{
    public Transform slotPosition;
    public List<GameObject> ingredientsOnPlate = new List<GameObject>();        // List of items currently on the plate

    // Attempt to add an ingredient to the plate
    public bool TryAddIngredient(GameObject ingredient)
    {
        string name = ingredient.name.ToLower();
        Debug.Log("Try to add" + name + "to plating area");

        if (name.Contains("plate"))     // Rule: Plate must be placed first
        {
            if (ingredientsOnPlate.Count == 0)
            {
                Debug.Log("place plate");
                AddToPlate(ingredient);     // Place plate if empty
                return true;
            }
        }
        else if (name.Contains("bun"))      // Rule: Bun must be second
        {
            if (ingredientsOnPlate.Count == 1)
            {
                AddToPlate(ingredient);     // Place bun on plate
                Debug.Log("Bun placed.");
                return true;
            }
        }
        else if (name.Contains("patty"))    // Rule: Patty must be third
        {
            if (ingredientsOnPlate.Count == 2)
            {
                AddToPlate(ingredient);     // Add patty
                return true;
            }
        }
        else if (name.Contains("lettuce") || name.Contains("tomato") || name.Contains("pickle"))    // Rule: Topping must be fourth
        {
            if (ingredientsOnPlate.Count == 3)
            {
                AddToPlate(ingredient);     // Add topping
                Debug.Log("Topping placed.");
                return true;
            }
        }

        return false;   //If not matched
    }

    //add the object and set its parent
    void AddToPlate(GameObject ingredient)
    {
        ingredientsOnPlate.Add(ingredient);                         //Add to the list
        ingredient.transform.SetParent(transform);                  //Make it a child of the plating area
        ingredient.transform.position = slotPosition.position;      //Move to the center of the Plating Area
    }

    // Clear all items from the plate
    public void ClearPlatingArea()
    {
        foreach (GameObject item in ingredientsOnPlate)
        {
            if (item != null) Destroy(item);
        }
        ingredientsOnPlate.Clear();     // Clear the list
    }

    //Try holding down the left mouse button to pick up the content of Plating Area and drag it.
    //public void BeginGroupPickup()
    //{
    //    if (ingredientsOnPlate.Count == 0) return;

    //    GameObject plate = ingredientsOnPlate[0];

    //    DragItem drag = plate.GetComponent<DragItem>();
    //    drag.isFromPlatingArea = true;

    //    for (int i = 1; i < ingredientsOnPlate.Count; i++)
    //    {
    //        ingredientsOnPlate[i].transform.SetParent(plate.transform);
    //    }

    //    MouseItem mouse = FindObjectOfType<MouseItem>();
    //    if (mouse != null)
    //    {
    //        mouse.currentItem = plate;
    //        Debug.Log("Begin group pickup: " + plate.name);
    //    }
    //}
}

