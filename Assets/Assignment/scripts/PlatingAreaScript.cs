using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatingAreaScript : MonoBehaviour
{
    public Transform slotPosition;
    public List<GameObject> ingredientsOnPlate = new List<GameObject>();

    public bool TryAddIngredient(GameObject ingredient)
    {
        string name = ingredient.name;
        Debug.Log("Try to add" + name + "to plating area");

        if (name.Contains("plate"))
        {
            if (ingredientsOnPlate.Count == 0)
            {
                Debug.Log("place plate");
                AddToPlate(ingredient);
                return true;
            }
        }
        else if (name.Contains("bun"))
        {
            if (ingredientsOnPlate.Count == 1 && ingredientsOnPlate[0].name.Contains("plate"))
            {
                AddToPlate(ingredient);
                return true;
            }
        }
        else if (name.Contains("patty"))
        {
            if (ingredientsOnPlate.Count == 2 && ingredientsOnPlate[1].name.ToLower().Contains("bun"))
            {
                CookState cook = ingredient.GetComponent<CookState>();
                if (cook != null && cook.cookTime >= 10)
                {
                    AddToPlate(ingredient);
                    return true;
                }
            }
        }
        else if (name.Contains("lettuce") || name.Contains("tomato") || name.Contains("pickle"))
        {
            if (ingredientsOnPlate.Count == 3)
            {
                AddToPlate(ingredient);
                return true;
            }
        }

        return false;
    }

    void AddToPlate(GameObject ingredient)
    {
        ingredientsOnPlate.Add(ingredient);
        ingredient.transform.SetParent(transform);
        ingredient.transform.position = slotPosition.position;
    }

    public void BeginGroupPickup()
    {
        if (ingredientsOnPlate.Count == 0) return;

        GameObject plate = ingredientsOnPlate[0];

        DragItem drag = plate.GetComponent<DragItem>();
        drag.isFromPlatingArea = true;

        for (int i = 1; i < ingredientsOnPlate.Count; i++)
        {
            ingredientsOnPlate[i].transform.SetParent(plate.transform);
        }

        // 设置 plate 为当前拖拽物体
        MouseItem mouse = FindObjectOfType<MouseItem>();
        if (mouse != null)
        {
            mouse.currentItem = plate;
            Debug.Log("Begin group pickup: " + plate.name);
        }
    }

    public void RemoveIngredient(GameObject ingredient)
    {
        if (ingredientsOnPlate.Contains(ingredient))
        {
            ingredientsOnPlate.Remove(ingredient);
            Debug.Log("Removed from plating area: " + ingredient.name);
        }
    }
}
