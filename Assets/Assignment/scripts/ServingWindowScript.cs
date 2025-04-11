using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ServingWindowScript : MonoBehaviour
{
    public PlatingAreaScript platingArea;
    public PattyGrillScript pattyGrill;
    public BunGrill bunGrill;
    public OrderScript orderScript;
    public TextMeshProUGUI moneyText;
    int playerMoney = 0;

    public UnityEvent onOrderSuccess = new UnityEvent();

    private void Start()
    {
        onOrderSuccess.AddListener(UpdateMoneyUI);
        onOrderSuccess.AddListener(PlayBonusEffect);
    }

    public void TryServeOrder()
    {
        List<GameObject> plateList = platingArea.ingredientsOnPlate;
        if (plateList.Count < 4)
        {
            return;
        }

        string foundPatty = "";
        string foundTopping = "";

        foreach (GameObject item in plateList)
        {
            if (item == null) continue;
            string name = item.name.ToLower();

            if (name.Contains("beef") || name.Contains("chicken") || name.Contains("fish"))
            {
                foundPatty = name;
            }
            else if (name.Contains("lettuce") || name.Contains("tomato") || name.Contains("pickle"))
            {
                foundTopping = name;
            }
        }

        string requiredPatty = orderScript.currentPatty;
        string requiredTopping = orderScript.currentTopping;

        if (foundPatty.Contains(requiredPatty) && foundTopping.Contains(requiredTopping))
        {
            Debug.Log("Order served! +$10");
            platingArea.ClearPlatingArea();
            playerMoney += 10;
            onOrderSuccess.Invoke();
            orderScript.GenerateRandomOrder();
        }
        else
        {
            Debug.Log("Order not matched.");
        }
    }

    public void ClearAll()
    {
        platingArea.ClearPlatingArea();
        pattyGrill.ClearGrill();
        bunGrill.ClearGrill();

        Debug.Log("Cleared all grills and plating area.");
    }

    void UpdateMoneyUI()
    {
        moneyText.text = playerMoney.ToString();
    }

    void PlayBonusEffect()
    {
        Debug.Log("Bonus effect played!");
    }
}
