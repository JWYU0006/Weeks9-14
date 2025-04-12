using UnityEngine;
using UnityEngine.UI;

public class OrderScript : MonoBehaviour
{
    public Image orderToppingImage;     //UI image for displaying required ingredients
    public Image orderPattyImage;

    public Sprite lettuceSprite;
    public Sprite tomatoSprite;
    public Sprite pickleSprite;

    public Sprite beefSprite;
    public Sprite chickenSprite;
    public Sprite fishSprite;

    public string currentTopping;       //Stores name of required ingredients
    public string currentPatty;

    void Start()
    {
        GenerateRandomOrder();      //Create a new order when the game starts
    }

    //Randomly generate a topping + patty order
    public void GenerateRandomOrder()
    {
        //Randomly choose topping
        string[] toppings = { "lettuce", "tomato", "pickle" };
        currentTopping = toppings[Random.Range(0, toppings.Length)];
        //Update topping image based on the selected name
        switch (currentTopping)
        {
            case "lettuce": orderToppingImage.sprite = lettuceSprite; break;
            case "tomato": orderToppingImage.sprite = tomatoSprite; break;
            case "pickle": orderToppingImage.sprite = pickleSprite; break;
        }
        //Randomly choose patty
        string[] patties = { "beef", "chicken", "fish" };
        currentPatty = patties[Random.Range(0, patties.Length)];
        //Update patty image based on the selected name
        switch (currentPatty)
        {
            case "beef": orderPattyImage.sprite = beefSprite; break;
            case "chicken": orderPattyImage.sprite = chickenSprite; break;
            case "fish": orderPattyImage.sprite = fishSprite; break;
        }

        Debug.Log("Order generated: " + currentPatty + " + " + currentTopping);
    }
}
