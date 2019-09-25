using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipmentPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject EquipmentPanel;
    [SerializeField]
    private PlayerEquipmentItemDescriptionPanel NewItemPanel;
    [SerializeField]
    private PlayerEquipmentItemDescriptionPanel CurrentItemPanel;
    [SerializeField]
    private GameObject Owner;
    [SerializeField]
    private List<PlayerEquipmentPanelSlot> Slots;
    private EquipmentSlotEnum SelectedSlot;

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        NewItemPanel.RemoveItemDescription();
        CurrentItemPanel.RemoveItemDescription();
        gameObject.SetActive(false);
    }

    public Item GetNewItem() {
        return NewItemPanel.Item;
    }

    public Item GetCurrentItem() {
        return CurrentItemPanel.Item;
    }

    public void SetNewItem(Item newItem) {
        NewItemPanel.SetItem(
            new OnUIItemDescribeEventData(Owner, NewItemPanel.transform),
            newItem
        );
    }

    public void SetCurrentItem(Item currentItem) {
        CurrentItemPanel.SetItem(
            new OnUIItemDescribeEventData(Owner, CurrentItemPanel.transform),
            currentItem
        );
    }

    public void ClearCurrentItem() {
        CurrentItemPanel.RemoveItemDescription();
        CurrentItemPanel.Item = null;
    }

    public PlayerEquipmentPanelSlot GetSelectedSlot() {
        foreach(PlayerEquipmentPanelSlot slot in Slots) {
            if(slot.EquipmentSlot == SelectedSlot) {
                return slot;
            }
        }
        return null;
    }

    public List<PlayerEquipmentPanelSlot> GetAllSlots() {
        return Slots;
    }

    public void SetSelectedSlot(EquipmentSlotEnum selectedSlot) {
        foreach(PlayerEquipmentPanelSlot slot in Slots) {
            if(slot.EquipmentSlot == selectedSlot) {
                SelectedSlot = selectedSlot;
                slot.GetComponent<Image>().enabled = true;
            } else {
                slot.GetComponent<Image>().enabled = false;
            }
        }
    }
}
