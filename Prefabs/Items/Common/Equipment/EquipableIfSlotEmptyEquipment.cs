using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipableIfSlotEmptyEquipment : MonoBehaviour {

    [SerializeField]
    EquipableToSlotEquipment EquipableTo;

    public void AttemptEquip(OnItemAttemptEquipEventData e) {
        EquipmentCollection equipment = e.Equipper.GetComponentInChildren<EquipmentCollection>();
        //only equip item if there is no item currently in slot
        if(EquipableTo.ContainsSlot(e.EquipmentSlot) &&
           !equipment.IsItemInSlot(e.EquipmentSlot) &&
           !equipment.IsEquipped(e.Item)
        ){
            e.Item.Emitter.Emit(
                new OnItemEquipEventData(
                    e.Equipper,
                    e.Item,
                    e.EquipmentSlot
                )
            );
        }
    }

    public void UIAttemptEquip(OnUIItemAttemptEquipEventData e) {
        EquipmentCollection equipment = e.Equipper.GetComponentInChildren<EquipmentCollection>();
        e.Item.UIEmitter.Emit(
            new OnUIItemEquipEventData(
                e.Equipper,
                e.EquipmentPanel.GetSelectedSlot()
            )
        );
        if(equipment.IsItemInSlot(e.EquipmentSlot)) {
            Item SelectedSlotItem = equipment.GetItemInSlot(e.EquipmentSlot);
            e.EquipmentPanel.SetCurrentItem(SelectedSlotItem);
        }
    }
}