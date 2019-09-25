using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentItemDescriptionPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject Title;
    public Item Item;

    private void ClearItemDescription() {
        foreach(Transform t in transform) {
            if (t == Title.transform) continue;
            Destroy(t.gameObject);
        }
    }

    public void SetItem(OnUIItemDescribeEventData descrption, Item item) {
        Item = item;
        ClearItemDescription();
        item.UIEmitter.Emit(descrption);
    }

    public void RemoveItemDescription() {
        ClearItemDescription();
    }
}
