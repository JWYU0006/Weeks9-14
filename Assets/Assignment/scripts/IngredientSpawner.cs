using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public Canvas canvas;       //parent canvas, make UI image rendered
    public GameObject beefPattyPrefab;      //store all prefab
    public GameObject chickenPattyPrefab;
    public GameObject fishPattyPrefab;
    public GameObject bunPrefab;
    public GameObject lettucePrefab;
    public GameObject tomatoPrefab;
    public GameObject picklePrefab;
    public GameObject platePrefab;
    public MouseItem mouseItem;
    public RectTransform pattyGrillRect;
    public RectTransform bunGrillRect;
    public RectTransform trashcanRect;
    public RectTransform platingAreaRect;
    public PattyGrillScript pattyGrill;
    public BunGrill bunGrill;

    // Update is called once per frame
    void Update()
    {

    }

    //set these functions to prefab's event trigger
    public void SpawnBeefPatty()
    {
        SpawnUIItem(beefPattyPrefab);   //pass the prefab need to be instantiated
    }

    public void SpawnchickenPatty()
    {
        SpawnUIItem(chickenPattyPrefab);
    }

    public void SpawnFishPatty()
    {
        SpawnUIItem(fishPattyPrefab);
    }

    public void SpawnBun()
    {
        SpawnUIItem(bunPrefab);
    }

    public void SpawnLettuce()
    {
        SpawnUIItem(lettucePrefab);
    }

    public void SpawnTomato()
    {
        SpawnUIItem(tomatoPrefab);
    }

    public void SpawnPickle()
    {
        SpawnUIItem(picklePrefab);
    }

    public void SpawnPlate()
    {
        SpawnUIItem(platePrefab);
    }

    void SpawnUIItem(GameObject prefab)
    {
        GameObject gameObject = Instantiate(prefab, canvas.transform);      //instantiate the prefab and set canvas as parent
        gameObject.GetComponent<RectTransform>().position = Input.mousePosition;        //set RectTransform after instantiate
        mouseItem.currentItem = gameObject;     //set current item in MouseItem class
        gameObject.GetComponent<UnityEngine.UI.Image>().raycastTarget = false;      //make grill pointer up event functional, otherwise it will block event trigger
        //pass the area detection object
        DragItem drag = gameObject.GetComponent<DragItem>();
        if (drag != null)
        {
            drag.pattyGrillRect = pattyGrillRect;
            drag.bunGrillRect = bunGrillRect;
            drag.trashcanRect = trashcanRect;
            drag.platingAreaRect = platingAreaRect;
        }

        CookState cookState = gameObject.GetComponent<CookState>();
        if (cookState != null)
        {
            if (prefab.name.Contains("patty"))
            {
                cookState.pattyGrill = pattyGrill;
            }
            else if (prefab.name.Contains("bun"))
            {
                cookState.bunGrill = bunGrill;
            }
        }
    }
}
