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

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBeefPatty()
    {
        SpawnUIItem(beefPattyPrefab);
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

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void SpawnUIItem(GameObject prefab)
    {
        GameObject gameObject = Instantiate(prefab, canvas.transform);
        gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
    }
}
