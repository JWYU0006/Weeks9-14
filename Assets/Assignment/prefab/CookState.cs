using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Added to prefab
public class CookState : MonoBehaviour
{
    public Sprite raw;
    public Sprite cooked;
    public Sprite burnt;

    public PattyGrillScript pattyGrill;
    public BunGrill bunGrill;
    public int slotIndex = -1;

    public bool isCooking = false;
    public float cookTime = 0;

    Coroutine cookRoutine;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCook()
    {
        if (!isCooking)
        {
            cookRoutine = StartCoroutine(CookProgress());
            isCooking = true;
        }
    }

    public void StopCook()
    {
        if (isCooking)
        {
            StopCoroutine(cookRoutine);
            isCooking = false;
        }
    }

    public void ResumeOnGrill()
    {
        if (pattyGrill != null)
        {
            //if successfully added to grill slot, start cook
            bool placed = pattyGrill.AddToSlot(gameObject);
            if (placed)
            {
                StartCook();
            }
        }
        else if (bunGrill != null)
        {
            bool placed = bunGrill.AddToSlot(gameObject);
            if (placed)
            {
                StartCook();
            }
        }
    }

    public void ReleaseFromGrill()
    {
        if (pattyGrill != null && slotIndex != -1)
        {
            //Debug.Log("Released from patty grill");
            pattyGrill.pattyInSlot[slotIndex] = null;
            pattyGrill.slotUsed[slotIndex] = false;
        }
        else if (bunGrill != null && slotIndex != -1)
        {
            //Debug.Log("Released from bun grill");
            bunGrill.bunInSlot[slotIndex] = null;
            bunGrill.slotUsed[slotIndex] = false;
        }

        slotIndex = -1;
    }

    IEnumerator CookProgress()
    {
        cookTime = 0;

        yield return new WaitForSeconds(0.5f);
        DragItem drag = GetComponent<DragItem>();
        if (drag != null)
        {
            drag.isDraggable = true;
        }

        while (cookTime <= 16)
        {
            cookTime += Time.deltaTime;

            if (cookTime >= 15)
            {
                image.sprite = burnt;
            }
            else if (cookTime >= 10)
            {
                image.sprite = cooked;
                //delete initial designed features, move to plating area automatically.
                PlatingAreaScript plating = FindObjectOfType<PlatingAreaScript>();
                if (plating != null && plating.TryAddIngredient(gameObject))
                {
                    Debug.Log("Auto moved to plating area.");
                    yield break;
                }
            }
            else
            {
                image.sprite = raw;
            }
            yield return null;
        }
    }
}
