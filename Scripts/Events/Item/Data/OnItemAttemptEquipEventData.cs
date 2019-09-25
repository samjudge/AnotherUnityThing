using UnityEngine;

public class OnItemAttemptEquipEventData
{
    public GameObject Equipper;
    public EquipmentSlotEnum EquipmentSlot;
    public Item Item;

    public OnItemAttemptEquipEventData(
        GameObject equipper,
        Item item,
        EquipmentSlotEnum toSlot
    ) {
        Equipper = equipper;
        EquipmentSlot = toSlot;
        Item = item;
    }
}