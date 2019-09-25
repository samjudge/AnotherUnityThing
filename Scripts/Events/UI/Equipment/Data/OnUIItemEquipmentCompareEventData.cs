using UnityEngine;

public class OnUIItemEquipmentCompareEventData
{
    public GameObject Player;
    public Item CurrentItem;
    public EquipmentDescriptionStatChangeCollection StatChangesCollection;
    public EquipmentSlotEnum ForSlot;

    public OnUIItemEquipmentCompareEventData(
        GameObject player,
        Item currentReplace,
        EquipmentDescriptionStatChangeCollection statChangesCollection,
        EquipmentSlotEnum forSlot
    )
    {
        Player = player;
        CurrentItem = currentReplace;
        StatChangesCollection = statChangesCollection;
        ForSlot = forSlot;
    }
}