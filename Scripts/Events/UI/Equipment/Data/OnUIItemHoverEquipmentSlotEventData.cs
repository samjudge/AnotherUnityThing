using UnityEngine;

public class OnUIItemHoverEquipmentSlotEventData
{
    public GameObject SelectorObject;
    public EquipmentSlotEnum Slot;

    public OnUIItemHoverEquipmentSlotEventData(EquipmentSlotEnum slot, GameObject selectorObject)
    {
        Slot = slot;
        SelectorObject = selectorObject;
    }
}