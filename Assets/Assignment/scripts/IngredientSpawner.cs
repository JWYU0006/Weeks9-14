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
        Vector3 spawnPos = GetMouseWorldPos();
        Instantiate(beefPattyPrefab, spawnPos, Quaternion.identity, canvas.transform);
    }

    public void SpawnchickenPatty()
    {
        Vector3 spawnPos = GetMouseWorldPos();
        Instantiate(chickenPattyPrefab, spawnPos, Quaternion.identity, canvas.transform);
    }

    public void SpawnFishPatty()
    {
        Vector3 spawnPos = GetMouseWorldPos();
        Instantiate(fishPattyPrefab, spawnPos, Quaternion.identity, canvas.transform);
    }

    public void SpawnBun()
    {
        Vector3 spawnPos = GetMouseWorldPos();
        Instantiate(bunPrefab, spawnPos, Quaternion.identity, canvas.transform);
    }

    public void SpawnLettuce()
    {
        Vector3 spawnPos = GetMouseWorldPos();
        Instantiate(lettucePrefab, spawnPos, Quaternion.identity, canvas.transform);
    }

    public void SpawnTomato()
    {
        Vector3 spawnPos = GetMouseWorldPos();
        Instantiate(tomatoPrefab, spawnPos, Quaternion.identity, canvas.transform);
    }

    public void SpawnPickle()
    {
        Vector3 spawnPos = GetMouseWorldPos();
        Instantiate(picklePrefab, spawnPos, Quaternion.identity, canvas.transform);
    }

    public void SpawnPlate()
    {
        Vector3 spawnPos = GetMouseWorldPos();
        Instantiate(platePrefab, spawnPos, Quaternion.identity, canvas.transform);
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
