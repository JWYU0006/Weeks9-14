using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BunGrill : MonoBehaviour
{
    public MouseItem mouseItem;
    public Transform[] grillSlots;      //4 slots, store the slot's position
    public bool[] slotUsed;        //if the slot is empty or not
    public GameObject[] bunInSlot;
    public DragItem dragItem;

    // Start is called before the first frame update
    void Start()
    {
        slotUsed = new bool[grillSlots.Length];
        bunInSlot = new GameObject[grillSlots.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(slotUsed[0] + ", " + mouseItem.currentItem.name);
    }

    public bool AddToSlot(GameObject bun)
    {
        for (int i = 0; i < grillSlots.Length; i++)
        {
            if (!slotUsed[i])
            {
                slotUsed[i] = true;
                bunInSlot[i] = bun;
                bun.GetComponent<DragItem>().wasDropped = true;

                CookState cookState = bun.GetComponent<CookState>();
                cookState.bunGrill = this;
                cookState.slotIndex = i;
                cookState.StartCook();

                bun.transform.position = grillSlots[i].position;
                bun.transform.SetParent(this.transform);
                return true;
            }
        }
        return false;
    }

    //IEnumerator Cook(GameObject bun)
    //{
    //    Debug.Log("Start cooking" + bun.name);
    //    CookState state = bun.GetComponent<CookState>();
    //    Image img = bun.GetComponent<Image>();

    //    yield return new WaitForSeconds(5);
    //    img.sprite = state.cooked;
    //    Debug.Log(bun.name + " cooked");

    //    yield return new WaitForSeconds(5);
    //    img.sprite = state.burnt;
    //    Debug.Log(bun.name + " burnt");
    //}

    public void ClearGrill()
    {
        for (int i = 0; i < bunInSlot.Length; i++)
        {
            if (bunInSlot[i] != null)
            {
                Destroy(bunInSlot[i]);
                bunInSlot[i] = null;
                slotUsed[i] = false;
            }
        }
    }
}
