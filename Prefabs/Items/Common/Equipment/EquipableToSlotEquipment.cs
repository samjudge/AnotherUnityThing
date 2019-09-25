using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipableToSlotEquipment : MonoBehaviour {
    [SerializeField]
    private List<EquipmentSlotEnum> CanEquipToSlots;

    public bool ContainsSlot(EquipmentSlotEnum slot)
    {
        foreach(EquipmentSlotEnum Slot in CanEquipToSlots) {
            if(Slot == slot) return true;
        }
        return false;
    }
}