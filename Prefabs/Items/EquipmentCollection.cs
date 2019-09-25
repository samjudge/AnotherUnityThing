using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCollection : MonoBehaviour
{
    private Dictionary<EquipmentSlotEnum, Item> Equipment;
    [SerializeField]
    private List<EquipmentSlotEnum> AvailiableSlots;

    void Awake(){
        Equipment = new Dictionary<EquipmentSlotEnum, Item>();
    }

    public void AddItemToSlot(EquipmentSlotEnum slot, Item item){
        if(AvailiableSlots.Contains(slot)) Equipment.Add(slot, item);
    }

    public List<Item> GetAllEquipmentItems(){
        return new List<Item>(Equipment.Values);
    }

    public bool IsEquipped(Item item) {
        foreach(EquipmentSlotEnum slot in GetAllSlots()) {
            if(Equipment.ContainsKey(slot)) {
                if(Equipment[slot] == item) return true;
            }
        }
        return false;
    }

    public EquipmentSlotEnum GetEquippedSlotOf(Item item){
        foreach(EquipmentSlotEnum slot in GetAllSlots()) {
            if(Equipment.ContainsKey(slot)) {
                if(Equipment[slot] == item) return slot;
            }
        }
        throw new UnknownItemException(
            "Could not find equipped slot of item `" + item.Label + "`"
        );
    }

    public bool IsItemInSlot(EquipmentSlotEnum slot){
        if(Equipment.ContainsKey(slot)) {
            return true;
        }
        return false;
    }

    public Item GetItemInSlot(EquipmentSlotEnum slot){
        if(Equipment.ContainsKey(slot)) {
            return Equipment[slot];
        }
        throw new UnknownItemException(
            "Could not find equipment in slot `" + slot.ToString() + "`"
        );
    }

    public void RemoveItemInSlot(EquipmentSlotEnum slot){
        if(AvailiableSlots.Contains(slot) &&
           Equipment.ContainsKey(slot)
        ) {
            Equipment.Remove(slot);
            return;
        }
        throw new UnknownItemException(
            "Attempted to remove item from empty index `" + slot.ToString() + "`"
        );
    }

    public List<EquipmentSlotEnum> GetAllSlots(){
        return AvailiableSlots;
    }
}
