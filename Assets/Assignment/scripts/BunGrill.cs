using UnityEngine;

//This script is based on PattyGrillScript
public class BunGrill : MonoBehaviour
{
    public Transform[] grillSlots;      //4 slots, store the slot's position
    public bool[] slotUsed;        //if the slot is empty or not
    public GameObject[] bunInSlot;

    // Start is called before the first frame update
    void Start()
    {
        slotUsed = new bool[grillSlots.Length];
        bunInSlot = new GameObject[grillSlots.Length];
    }

    public bool AddToSlot(GameObject bun)
    {
        for (int i = 0; i < grillSlots.Length; i++)
        {
            if (!slotUsed[i])
            {
                slotUsed[i] = true;
                bunInSlot[i] = bun;

                CookState cookState = bun.GetComponent<CookState>();
                if (cookState != null)
                {
                    cookState.bunGrill = this;
                    cookState.slotIndex = i;
                }

                bun.transform.position = grillSlots[i].position;
                return true;
            }
        }
        return false;
    }

    public void RemoveFromSlot(int index)
    {
        if (index >= 0 && index < slotUsed.Length)
        {
            slotUsed[index] = false;
            bunInSlot[index] = null;
        }
    }

    public void ClearGrill()
    {
        for (int i = 0; i < bunInSlot.Length; i++)
        {
            if (bunInSlot[i] != null)
            {
                Destroy(bunInSlot[i]);
            }
            bunInSlot[i] = null;
            slotUsed[i] = false;
        }
    }
}
