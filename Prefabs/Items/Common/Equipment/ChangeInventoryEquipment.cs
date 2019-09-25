using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInventoryEquipment : MonoBehaviour {

    public void Equip(OnItemEquipEventData e) {
        EquipmentCollection equipment = e.Equipper
            .GetComponentInChildren<EquipmentCollection>();
        //add item to slot
        equipment.AddItemToSlot(e.EquipmentSlot, e.Item);
    }

    public void Unequip(OnItemUnequipEventData e){
        EquipmentCollection equipment = e.Equipper
            .GetComponentInChildren<EquipmentCollection>();
        if(equipment.IsItemInSlot(e.EquipmentSlot)){
            equipment.RemoveItemInSlot(e.EquipmentSlot);
        }
    }
}