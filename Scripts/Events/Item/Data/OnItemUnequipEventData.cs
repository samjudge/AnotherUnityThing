using UnityEngine;

public class OnItemUnequipEventData
{
    public GameObject Equipper;
    public EquipmentSlotEnum EquipmentSlot;
    public Item Item;

    public OnItemUnequipEventData(
        GameObject equipper,
        Item item,
        EquipmentSlotEnum fromSlot
    ) {
        Equipper = equipper;
        EquipmentSlot = fromSlot;
        Item = item;
    }
}