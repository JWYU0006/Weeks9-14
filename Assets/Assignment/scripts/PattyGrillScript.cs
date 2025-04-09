using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PattyGrillScript : MonoBehaviour
{
    public MouseItem mouseItem;
    public Transform[] grillSlots;      //4 slots, store the slot's position
    bool[] slotUsed;        //if the slot is empty or not
    public DragItem dragItem;

    // Start is called before the first frame update
    void Start()
    {
        slotUsed = new bool[grillSlots.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(slotUsed[0] + ", " + mouseItem.currentItem.name);
    }

    public void TryGrill()
    {
        Debug.Log("TryGrill called");
        if (mouseItem.currentItem == null) return;      //if no item is dragged, nothing happens

        if (mouseItem.currentItem.name.Contains("patty"))
        {
            if (AddToSlot(mouseItem.currentItem))
            {
                mouseItem.currentItem = null;
                return;
            }
        }
        mouseItem.currentItem = null;
        //Debug.Log(slotUsed[0] + ", " + mouseItem.currentItem.name);
    }

    bool AddToSlot(GameObject patty)
    {
        for (int i = 0; i < grillSlots.Length; i++)
        {
            if (!slotUsed[i])
            {
                patty.GetComponent<DragItem>().wasDropped = true;
                patty.transform.position = grillSlots[i].position;
                slotUsed[i] = true;
                patty.transform.SetParent(this.transform);
                StartCoroutine(Cook(patty));
                return true;
            }
        }
        return false;
    }

    IEnumerator Cook(GameObject patty)
    {
        Debug.Log("Start cooking" + patty.name);
        CookState state = patty.GetComponent<CookState>();
        Image img = patty.GetComponent<Image>();

        yield return new WaitForSeconds(3);
        img.sprite = state.cooked;
        Debug.Log(patty.name + " cooked");

        yield return new WaitForSeconds(1);
        img.sprite = state.burnt;
        Debug.Log(patty.name + " burnt");
    }
}
