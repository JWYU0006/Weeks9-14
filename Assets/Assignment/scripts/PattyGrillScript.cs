using UnityEngine;

public class PattyGrillScript : MonoBehaviour
{
    public MouseItem mouseItem;
    public Transform[] grillSlots;      //4 slots, store the slot's position
    public bool[] slotUsed;        //if the slot is empty or not
    public GameObject[] pattyInSlot;       //Store the patty in each slot
    public DragItem dragItem;

    // Start is called before the first frame update
    void Start()
    {
        slotUsed = new bool[grillSlots.Length];     //initialize all array, have same length with grillSlots
        pattyInSlot = new GameObject[grillSlots.Length];
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

    public bool AddToSlot(GameObject patty)
    {
        CookState cookState = patty.GetComponent<CookState>();
        if (cookState != null && cookState.isPlacedOnGrill)
        {
            Debug.Log("Skipping AddToSlot ¡ª already placed once.");
            return true;
        }

        for (int i = 0; i < grillSlots.Length; i++)
        {
            if (!slotUsed[i])
            {
                slotUsed[i] = true;
                pattyInSlot[i] = patty;
                patty.GetComponent<DragItem>().wasDropped = true;

                cookState.pattyGrill = this;
                cookState.slotIndex = i;
                cookState.StartCook();
                patty.transform.position = grillSlots[i].position;
                patty.transform.SetParent(this.transform);
                Debug.Log("AddToSlot called for: " + patty.name);
                return true;
            }
        }
        Debug.Log("patty grill no free slot for " + patty.name);
        return false;
    }

    //IEnumerator Cook(GameObject patty)
    //{
    //    Debug.Log("Start cooking" + patty.name);
    //    CookState state = patty.GetComponent<CookState>();
    //    Image img = patty.GetComponent<Image>();

    //    yield return new WaitForSeconds(10);
    //    img.sprite = state.cooked;
    //    Debug.Log(patty.name + " cooked");

    //    yield return new WaitForSeconds(5);
    //    img.sprite = state.burnt;
    //    Debug.Log(patty.name + " burnt");
    //}
}
