using UnityEngine;

//Added to empty object: Spawner
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
    public RectTransform pattyGrillRect;        //store position where can drop item
    public RectTransform bunGrillRect;
    public RectTransform trashcanRect;
    public RectTransform platingAreaRect;
    public MouseItem mouseItem;     //script reference
    public PattyGrillScript pattyGrill;
    public BunGrill bunGrill;
    public PlatingAreaScript platingArea;

    //set these functions to prefab's event trigger
    public void SpawnBeefPatty()
    {
        //Debug.Log("spawn beef patty");
        SpawnUIItem(beefPattyPrefab);   //pass the prefab need to be instantiated
    }

    public void SpawnchickenPatty()
    {
        //Debug.Log("spawn chicken patty");
        SpawnUIItem(chickenPattyPrefab);
    }

    public void SpawnFishPatty()
    {
        //Debug.Log("spawn fish patty");
        SpawnUIItem(fishPattyPrefab);
    }

    public void SpawnBun()
    {
        //Debug.Log("spawn bun");
        SpawnUIItem(bunPrefab);
    }

    public void SpawnLettuce()
    {
        //Debug.Log("spawn lettuce");
        SpawnUIItem(lettucePrefab);
    }

    public void SpawnTomato()
    {
        //Debug.Log("spawn tomato");
        SpawnUIItem(tomatoPrefab);
    }

    public void SpawnPickle()
    {
        //Debug.Log("spawn pickle");
        SpawnUIItem(picklePrefab);
    }

    public void SpawnPlate()
    {
        //Debug.Log("spawn plate");
        SpawnUIItem(platePrefab);
    }

    void SpawnUIItem(GameObject prefab)
    {
        GameObject gameObject = Instantiate(prefab, canvas.transform);      //instantiate the prefab and set canvas as parent
        Debug.Log("spawn " + prefab.name + ": " + gameObject.name);
        //gameObject.GetComponent<RectTransform>().position = Input.mousePosition;        //set RectTransform after instantiate
        mouseItem.currentItem = gameObject;     //set current item in MouseItem class
        gameObject.GetComponent<UnityEngine.UI.Image>().raycastTarget = true;

        DragItem drag = gameObject.GetComponent<DragItem>();        //pass the area detection object
        if (drag != null)
        {
            drag.pattyGrillRect = pattyGrillRect;
            drag.bunGrillRect = bunGrillRect;
            drag.trashcanRect = trashcanRect;
            drag.platingAreaRect = platingAreaRect;
            drag.pattyGrill = pattyGrill;
            drag.bunGrill = bunGrill;
            drag.platingArea = platingArea;
            //drag.mouseItem = mouseItem;
            drag.canvas = canvas;
        }

        //set grill according to prefab's name
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
