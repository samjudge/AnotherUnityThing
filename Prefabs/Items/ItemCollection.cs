using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    private List<Item> Items;

    void Awake(){
        this.Items = new List<Item>();
        Item[] Items = GetComponentsInChildren<Item>();
        for(int x = 0; x < Items.Length; x++){
            this.Items[x] = Items[x];
        }
    }

    public void AddItem(Item i){
        i.transform.SetParent(transform);
        i.transform.localPosition = Vector3.zero;
        Items.Add(i);
    }

    public List<Item> GetItems(){
        return Items;
    }

    public Item GetItemAtIndexAndCategory(int index, Item.ItemTag category){
        int originalIndex = index;
        for (int x = 0; x < Items.Count; x++) {
            if(Items[x].Category == category) {
                index--;
            }
            if(index == -1){
                return Items[x];
            }
        }
        throw new UnknownItemException(
            "Could not find item at index `" + originalIndex + "` in category `" + category + "`"
        );
    }

    public void RemoveItemAtIndex(int forIndex){
        if(Items[forIndex] == null) {
            throw new UnknownItemException(
                "Attempted to remove item from empty index `" + forIndex + "`"
            );
        }
        Items.RemoveAt(forIndex);
    }

    public void RemoveItem(Item i){
        List<Item> Items = GetItems();
        for(int x = 0; x < Items.Count; x++){
            Item it = GetItems()[x];
            if(it == i) {
                RemoveItemAtIndex(x);
                return;
            }
        }
        throw new UnknownItemException(
            "Attempted to remove non-existant item `" + i.Label + "`"
        );
    }

    private int GetFirstEmptyIndex(){
        for(int x = 0; x < Items.Count; x++){
            if(Items[x] == null) return x;
        }
        return Items.Count;
    }

    public Item GetItemAtIndex(int index){
        if(index < 0 || index >= Items.Count || GetItems()[index] == null) {
            throw new UnknownItemException(
                "Attempted to get item exists at empty index `" + index + "`"
            );
        }
        return GetItems()[index];
    }
}
