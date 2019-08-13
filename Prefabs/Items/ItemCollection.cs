using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    private List<Item> Items;

    void Awake(){
        this.Items = new List<Item>();
        Item[] Items = this.GetComponentsInChildren<Item>();
        this.Items.AddRange(Items);
    }

    public void AddItem(Item i){
        i.transform.SetParent(transform);
        i.transform.localPosition = Vector3.zero;
        Items.Add(i);
    }

    public List<Item> GetItems(){
        return Items;
    }

    public void RemoveItem(Item i){
        List<Item> Items = GetItems();
        for(int x = 0; x < Items.Count; x++){
            Item it = GetItems()[x];
            if(it == i) {
                this.Items.Remove(i);
                return;
            }
        }
        throw new UnknownItemException(
            "Attempted to remove non-existant item `" + i.Label + "`"
        );
    }

    public Item GetItemAtIndex(int Index){
        if(Index < 0 || Index >= Items.Count) {
            throw new UnknownItemException(
                "No item exists at index `" + Index + "`"
            );
        }
        return GetItems()[Index];
    }
}
