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

        if (name.Contains("plate"))
        {
            if (ingredientsOnPlate.Count == 0)
            {
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
}
