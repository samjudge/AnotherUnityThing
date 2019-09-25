using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryItems : MonoBehaviour
{
    [SerializeField]
    private EquipmentCollection PlayerEquipment;
    [SerializeField]
    private ItemCollection PlayerInventory;
    [SerializeField]
    private PlayerUIControl ItemUIControl;
    [SerializeField]
    private PlayerUIControl CategryUIControl;
    [SerializeField]
    private PlayerEquipmentPanel EquipmentPanel;
    [SerializeField]
    private Transform DescriptionPanel;
    [SerializeField]
    private PlayerUIControlLine LinePrefab;
    [SerializeField]
    private OnKeyboardEventHandler KeyboardInput;
    [SerializeField]
    private GameObject Owner;
    [SerializeField]
    private RectTransform MovementTransform;
    [SerializeField]
    private EquipmentDescriptionStatChangeCollection EquipmentUIStatComparison;

    private Item.ItemTag CurrentCategory;

    private enum Panels { Category, Item, Equipment }
    private Stack<int> VerticalIndexStack;
    private Panels CurrentPanel;
    private Stack<Panels> CurrentPanelStack;
    private int VerticalIndex = 0;
    private bool IsOpen = false;

    public void MoveSelectedIndexOnKey(OnKeyDownEventData e){
        switch(e.Key){
            case KeyCode.J:
                VerticalIndex++;
                break;
            case KeyCode.K:
                VerticalIndex--;
                break;
        }
        RefreshRenderedItems();
        RefreshComparedItems();
    }

    public void UseItemOnKey(OnKeyDownEventData e){
        if(isMoving) return;
        switch(e.Key){
            case KeyCode.L:
                if(CurrentPanel == Panels.Category) {
                    if(VerticalIndex < 0 || VerticalIndex > CategryUIControl.Lines.GetSize() - 1) {
                        return;
                    }
                    VerticalIndexStack.Push(VerticalIndex);
                    CategryUIControl.Lines.Get(VerticalIndex).GetComponent<Animator>().enabled = false;
                    VerticalIndex = 0;
                    CurrentPanel = Panels.Item;
                    StartCoroutine(Move(new Vector3(-183.1666f, 0f, 0f), 0.5f));
                } else if(CurrentPanel == Panels.Item) {
                    if(VerticalIndex < 0 || VerticalIndex > ItemUIControl.Lines.GetSize() - 1) {
                        return;
                    }
                    Item i = PlayerInventory.GetItemAtIndexAndCategory(VerticalIndex, CurrentCategory);
                    i.Emitter.Emit(
                        new OnItemUseEventData(Owner)
                    );
                    if(CurrentCategory == Item.ItemTag.Armour ||
                       CurrentCategory == Item.ItemTag.Weapon
                    ) {
                        CurrentPanelStack.Push(CurrentPanel);
                        VerticalIndexStack.Push(VerticalIndex);
                        EquipmentPanel.gameObject.SetActive(true);
                        EquipmentPanel.Show();
                        EquipmentPanel.SetNewItem(i);
                        foreach(PlayerEquipmentPanelSlot slot in EquipmentPanel.GetAllSlots()){
                            if(PlayerEquipment.IsItemInSlot(slot.EquipmentSlot)){
                                Item uii = PlayerEquipment.GetItemInSlot(slot.EquipmentSlot);
                                uii.UIEmitter.Emit(new OnUIItemEquipEventData(
                                    Owner,
                                    slot
                                ));
                                EquipmentPanel.SetCurrentItem(uii);
                            }
                        }
                        CurrentPanel = Panels.Equipment;
                        RefreshComparedItems();
                    }
                } else if(CurrentPanel == Panels.Equipment) {
                    Item i = EquipmentPanel.GetNewItem();
                    i.Emitter.Emit(new OnItemAttemptEquipEventData(
                        Owner,
                        i,
                        EquipmentPanel.GetSelectedSlot().EquipmentSlot
                    ));
                    i.UIEmitter.Emit(new OnUIItemAttemptEquipEventData(
                        Owner,
                        i,
                        EquipmentPanel,
                        EquipmentPanel.GetSelectedSlot().EquipmentSlot
                    ));
                    RefreshComparedItems();
                }
                RefreshRenderedItems();
                break;
            case KeyCode.H:
                if(CurrentPanel == Panels.Item) {
                    if(VerticalIndex >= 0 && VerticalIndex < ItemUIControl.Lines.GetSize()) {
                        ItemUIControl.Lines.Get(VerticalIndex).Selector.GetComponent<Image>().enabled = false;
                    }
                    VerticalIndex = VerticalIndexStack.Pop();
                    CategryUIControl.Lines.Get(VerticalIndex).GetComponent<Animator>().enabled = true;
                    CurrentPanel = Panels.Category;
                    StartCoroutine(Move(new Vector3(183.1666f, 0f, 0f), 0.5f));
                } else if(CurrentPanel == Panels.Equipment) {
                    EquipmentPanel.Close();
                    CurrentPanel = CurrentPanelStack.Pop();
                    VerticalIndex = VerticalIndexStack.Pop();
                }
                break;
            case KeyCode.X:
                if(CurrentPanel == Panels.Equipment &&
                   PlayerEquipment.IsItemInSlot(EquipmentPanel.GetSelectedSlot().EquipmentSlot)
                ) {
                    Item uii = PlayerEquipment.GetItemInSlot(EquipmentPanel.GetSelectedSlot().EquipmentSlot);
                    uii.Emitter.Emit(new OnItemUnequipEventData(
                        Owner,
                        uii,
                        EquipmentPanel.GetSelectedSlot().EquipmentSlot
                    ));
                    uii.UIEmitter.Emit(new OnUIItemUnequipEventData(Owner, EquipmentPanel.GetSelectedSlot()));
                    RefreshComparedItems();
                }
                break;
        }
    }

    void Start() {
        VerticalIndexStack = new Stack<int>();
        CurrentPanelStack = new Stack<Panels>();
        ItemUIControl.Title.Item.Text.text = "Inventory";
        SetIsOpen(false);
        CurrentPanel = Panels.Category;
        RefreshRenderedItems();
        RefreshComparedItems();
    }

    void Update() {
        if(CurrentPanel == Panels.Item) {
            if (VerticalIndex < 0){
                VerticalIndex = 0;
            } else if (VerticalIndex > ItemUIControl.Lines.GetSize() - 1) {
                VerticalIndex = ItemUIControl.Lines.GetSize() - 1;
            }
            for(int x = 0; x < ItemUIControl.Lines.GetSize(); x++) {
                if(x != VerticalIndex) {
                    ItemUIControl.Lines.Get(x).Selector.GetComponent<Image>().enabled = false;
                } else {
                    ItemUIControl.Lines.Get(x).Selector.GetComponent<Image>().enabled = true;
                    foreach(Transform t in DescriptionPanel.transform){
                        Destroy(t.gameObject);
                    }
                    if(CurrentCategory ==
                        PlayerInventory.GetItemAtIndexAndCategory(
                            VerticalIndex,
                            CurrentCategory
                        ).Category
                    ) {
                        PlayerInventory.GetItemAtIndexAndCategory(
                            VerticalIndex,
                            CurrentCategory
                        ).UIEmitter.Emit(new OnUIItemDescribeEventData(
                            Owner,
                            DescriptionPanel
                        ));
                    }
                }
            }
        } else if(CurrentPanel == Panels.Category) {
            if (VerticalIndex < 0) {
                VerticalIndex = 0;
            } else if (VerticalIndex > CategryUIControl.Lines.GetSize() - 1) {
                VerticalIndex = CategryUIControl.Lines.GetSize() - 1;
            }
            for(int x = 0; x < CategryUIControl.Lines.GetSize(); x++) {
                if(x != VerticalIndex) {
                    CategryUIControl.Lines.Get(x).Selector.GetComponent<Image>().enabled = false;
                } else {
                    CategryUIControl.Lines.Get(x).Selector.GetComponent<Image>().enabled = true;
                }
            }
        } else if(CurrentPanel == Panels.Equipment) {
            if (VerticalIndex < 0) {
                VerticalIndex = 0;
            } else if (VerticalIndex > PlayerEquipment.GetAllSlots().Count - 1) {
                VerticalIndex = PlayerEquipment.GetAllSlots().Count - 1;
            }
            if(PlayerEquipment.IsItemInSlot((EquipmentSlotEnum) VerticalIndex)) {
                Item SelectedSlotItem = PlayerEquipment.GetItemInSlot((EquipmentSlotEnum) VerticalIndex);
                EquipmentPanel.SetCurrentItem(SelectedSlotItem);
                RefreshComparedItems();
            } else {
                EquipmentPanel.ClearCurrentItem();
                RefreshComparedItems();
            }
            EquipmentPanel.SetSelectedSlot((EquipmentSlotEnum) VerticalIndex);
            foreach(PlayerEquipmentPanelSlot slot in EquipmentPanel.GetAllSlots()){
                if(PlayerEquipment.IsItemInSlot(slot.EquipmentSlot)){
                    slot.ItemImage.enabled = true;
                } else {
                    slot.ItemImage.enabled = false;
                }
            }
            EquipmentPanel.GetNewItem().UIEmitter.Emit(new OnUIItemHoverEquipmentSlotEventData(
                EquipmentPanel.GetSelectedSlot().EquipmentSlot,
                EquipmentPanel.GetSelectedSlot().gameObject
            ));
        }
    }

    public void RefreshComparedItems(){
        if(EquipmentPanel.GetNewItem() != null) {
            EquipmentPanel.GetNewItem().UIEmitter.Emit(new OnUIItemEquipmentCompareEventData(
                Owner,
                EquipmentPanel.GetCurrentItem(),
                EquipmentUIStatComparison,
                EquipmentPanel.GetSelectedSlot().EquipmentSlot
            ));
        }
    }

    private bool wantsToClose = false;

    public void ToggleIsOpen(){
        if(!isMoving){
            RefreshRenderedItems();
            IsOpen = !IsOpen; 
            gameObject.SetActive(IsOpen);
        }
    }

    public void SetIsOpen(bool IsOpen){
        this.IsOpen = IsOpen;
        gameObject.SetActive(IsOpen);
    }

    public void RefreshRenderedItems(){
        List<Item> Items = PlayerInventory.GetItems();
        ItemUIControl.Lines.Clear();
        if(CurrentPanel == Panels.Category) CurrentCategory = (Item.ItemTag) VerticalIndex;
        for(int x = 0; x < Items.Count; x++){
            if(CurrentCategory == Items[x].Category) {
                PlayerUIControlLine Item = Instantiate(LinePrefab);
                Item.Icon = Items[x].UIItemImage;
                Item.Text.text = Items[x].Label;
                ItemUIControl.Lines.Add(Item);
            }
        }
    }

    private bool isMoving = false;

    public IEnumerator Move(Vector3 px, float duration){
        isMoving = true;
        float cDuration = 0;
        Vector3 target = MovementTransform.localPosition + px;
        while(cDuration < duration){
            MovementTransform.localPosition =
                Vector3.Lerp(MovementTransform.localPosition, target, cDuration);
            cDuration += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
    }
}
