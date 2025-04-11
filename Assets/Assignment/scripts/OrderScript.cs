using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderScript : MonoBehaviour
{
    public Image orderToppingImage;
    public Image orderPattyImage;

    public Sprite lettuceSprite;
    public Sprite tomatoSprite;
    public Sprite pickleSprite;

    public Sprite beefSprite;
    public Sprite chickenSprite;
    public Sprite fishSprite;

    public string currentTopping;
    public string currentPatty;

    void Update()
    {
        if (orderPattyImage.sprite == null)
        {
            GenerateRandomOrder();
        }
    }

    public void GenerateRandomOrder()
    {
        //Randomly generate topping
        string[] toppings = { "lettuce", "tomato", "pickle" };
        string randomTopping = toppings[Random.Range(0, toppings.Length)];
        currentTopping = randomTopping;

        switch (randomTopping)
        {
            case "lettuce": orderToppingImage.sprite = lettuceSprite; break;
            case "tomato": orderToppingImage.sprite = tomatoSprite; break;
            case "pickle": orderToppingImage.sprite = pickleSprite; break;
        }

        //Randomly generate patty
        string[] patties = { "beef", "chicken", "fish" };
        string randomPatty = patties[Random.Range(0, patties.Length)];
        currentPatty = randomPatty;

        switch (randomPatty)
        {
            case "beef": orderPattyImage.sprite = beefSprite; break;
            case "chicken": orderPattyImage.sprite = chickenSprite; break;
            case "fish": orderPattyImage.sprite = fishSprite; break;
        }

        Debug.Log("Order generated: " + currentPatty + " + " + currentTopping);
    }
}
