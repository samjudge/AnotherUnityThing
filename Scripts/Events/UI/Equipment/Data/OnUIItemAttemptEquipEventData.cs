using UnityEngine;

public class OnUIItemAttemptEquipEventData
{
    public GameObject Equipper;
    public Item Item;
    public PlayerEquipmentPanel EquipmentPanel;
    public EquipmentSlotEnum EquipmentSlot;

    public OnUIItemAttemptEquipEventData(
        GameObject equipper,
        Item item,
        PlayerEquipmentPanel equipmentPanel,
        EquipmentSlotEnum equipmentSlot
    ) {
        Equipper = equipper;
        Item = item;
        EquipmentPanel = equipmentPanel;
        EquipmentSlot = equipmentSlot;
    }
}