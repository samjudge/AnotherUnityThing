using UnityEngine;

public class OnItemEquipEventData
{
    public GameObject Equipper;
    public EquipmentSlotEnum EquipmentSlot;
    public Item Item;

    public OnItemEquipEventData(
        GameObject equipper,
        Item item,
        EquipmentSlotEnum toSlot
    ) {
        Equipper = equipper;
        EquipmentSlot = toSlot;
        Item = item;
    }
}