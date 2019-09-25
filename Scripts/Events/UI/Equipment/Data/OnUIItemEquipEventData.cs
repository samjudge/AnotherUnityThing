using UnityEngine;

public class OnUIItemEquipEventData
{
    public GameObject Equipper;
    public PlayerEquipmentPanelSlot EquipmentSlotParent;

    public OnUIItemEquipEventData(GameObject equipper, PlayerEquipmentPanelSlot equipmentSlotParent)
    {
        Equipper = equipper;
        EquipmentSlotParent = equipmentSlotParent;
    }
}