using UnityEngine;

public class PattyGrillScript : MonoBehaviour
{
    public Transform[] grillSlots;      //4 slots, store the slot's position
    public bool[] slotUsed;             //if the slot is empty or not
    public GameObject[] pattyInSlot;    //Store the patty in each slot

    // Start is called before the first frame update
    void Start()
    {
        slotUsed = new bool[grillSlots.Length];     //initialize all array, have same length with grillSlots
        pattyInSlot = new GameObject[grillSlots.Length];
    }

    // Attempt to add a patty to the first available slot
    public bool AddToSlot(GameObject patty)
    {
        for (int i = 0; i < grillSlots.Length; i++)
        {
            if (!slotUsed[i])
            {
                slotUsed[i] = true;     // Mark slot as used
                pattyInSlot[i] = patty;
                //patty.GetComponent<DragItem>().wasDropped = true;

                CookState cookState = patty.GetComponent<CookState>();
                if (cookState != null)
                {
                    cookState.pattyGrill = this;
                    cookState.slotIndex = i;
                }

                // Move patty to grill slot
                patty.transform.position = grillSlots[i].position;
                //patty.transform.SetParent(this.transform);

                Debug.Log("AddToSlot called for: " + patty.name);
                return true;
            }
        }
        Debug.Log("patty grill no free slot for " + patty.name);
        return false;
    }

    // Remove a patty from a specific slot
    public void RemoveFromSlot(int index)
    {
        if (index >= 0 && index < slotUsed.Length)
        {
            slotUsed[index] = false;
            pattyInSlot[index] = null;
        }
    }

    // Clear all patties from the grill
    public void ClearGrill()
    {
        for (int i = 0; i < pattyInSlot.Length; i++)
        {
            if (pattyInSlot[i] != null)
            {
                Destroy(pattyInSlot[i]);
            }
            pattyInSlot[i] = null;
            slotUsed[i] = false;
        }
    }
}
