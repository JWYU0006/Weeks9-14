using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    IEnumerator CookProgress()
    {
        cookTime = 0;
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
            }
            else
            {
                image.sprite = raw;
            }
            yield return null;
        }
    }
}
