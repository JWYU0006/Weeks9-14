using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ServingWindowScript : MonoBehaviour
{
    public PlatingAreaScript platingArea;       //reference to the Plating Area script (stores current plate contents)
    public PattyGrillScript pattyGrill;         //to the Patty Grill Script
    public BunGrill bunGrill;                   //to the Bun Grill script
    public OrderScript orderScript;             // Reference to the current order system
    public TextMeshProUGUI moneyText;           // Text UI element displaying the player's money
    int playerMoney = 0;                        // Player's current money
    bool bonusEffectEnabled = true;             // Controls whether the bonus effect is still active

    public UnityEvent onOrderSuccess = new UnityEvent();        // UnityEvent triggered when a correct order is served

    void Start()
    {
        // Register two listeners to the UnityEvent
        onOrderSuccess.AddListener(UpdateMoneyUI);      // Always updates the money UI
        onOrderSuccess.AddListener(PlayBonusEffect);    // Plays a bonus effect unless removed later
    }

    // This method is called when the player clicks the serving window
    public void TryServeOrder()
    {
        List<GameObject> plateList = platingArea.ingredientsOnPlate;        // Get current ingredients on the plate
        if (plateList.Count < 4) return;        // Need at least 4 items: plate, bun, patty, topping

        // Will hold the type of patty and topping found
        string foundPatty = "";
        string foundTopping = "";

        // Check each ingredient on the plate and identify its type
        foreach (GameObject item in plateList)
        {
            if (item == null) continue;
            string name = item.name.ToLower();

            if (name.Contains("beef") || name.Contains("chicken") || name.Contains("fish"))
            {
                foundPatty = name;      // Set patty type
            }
            else if (name.Contains("lettuce") || name.Contains("tomato") || name.Contains("pickle"))
            {
                foundTopping = name;        // Set topping type
            }
        }

        // Get the correct order requirements from the OrderScript
        string requiredPatty = orderScript.currentPatty;
        string requiredTopping = orderScript.currentTopping;

        // Compare player's plate contents with the required order
        if (foundPatty.Contains(requiredPatty) && foundTopping.Contains(requiredTopping))
        {
            Debug.Log("Order served! +$10");
            playerMoney += 10;
            platingArea.ClearPlatingArea();         // Clear the plate contents
            orderScript.GenerateRandomOrder();      // Generate a new random order

            // Once player gets more than $50, remove the bonus listener (only once)
            if (playerMoney > 50 && bonusEffectEnabled)
            {
                onOrderSuccess.RemoveListener(PlayBonusEffect);     // Remove the bonus effect
                bonusEffectEnabled = false;                         // Prevent this from running again
                Debug.Log("Bonus effect removed (playerMoney > 50)");
            }

            onOrderSuccess.Invoke();        // Trigger all listeners attached to the event
        }
        else
        {
            Debug.Log("Order not matched.");
        }
    }

    // Called when the trashcan is clicked: clears all grills and plating area
    public void ClearAll()
    {
        platingArea.ClearPlatingArea();
        pattyGrill.ClearGrill();
        bunGrill.ClearGrill();

        Debug.Log("Cleared all grills and plating area.");
    }

    // Listener method: updates the money text UI
    void UpdateMoneyUI()
    {
        moneyText.text = playerMoney.ToString();
    }

    // Listener method: plays bonus effect
    void PlayBonusEffect()
    {
        Debug.Log("Bonus effect played!");
    }
}
