using UnityEngine;

public class OnUIItemUnequipEventData
{
    public GameObject Equipper;
    public PlayerEquipmentPanelSlot EquipmentSlotParent;

    public OnUIItemUnequipEventData(GameObject equipper, PlayerEquipmentPanelSlot equipmentSlotParent)
    {
        Equipper = equipper;
        EquipmentSlotParent = equipmentSlotParent;
    }
}