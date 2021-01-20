using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
    

public class MergeController : MonoBehaviour
{
    [SerializeField] List<RuneSlot> runeSlots = new List<RuneSlot>();

    public void CollectRuneSlots()
    {
        runeSlots.Clear();
        foreach (var slot in GetComponentsInChildren<RuneSlot>())
        {
            if(slot.dragSlot != null)
                runeSlots.Add(slot);
        }
    }
}
