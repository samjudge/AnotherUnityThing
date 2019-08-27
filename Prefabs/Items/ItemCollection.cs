using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    private Dictionary<int, Item> Items;

    void Awake(){
        this.Items = new Dictionary<int, Item>();
        Item[] Items = GetComponentsInChildren<Item>();
        for(int x = 0; x < Items.Length; x++){
            this.Items[x] = Items[x];
        }
    }

    public void AddItem(int toIndex, Item i){
        i.transform.SetParent(transform);
        i.transform.localPosition = Vector3.zero;
        Items[toIndex] = i;
    }

    public void AddItemToFirstEmptyIndex(Item i){
        Debug.Log(GetFirstEmptyIndex());
        Items[GetFirstEmptyIndex()] = i;
    }

    public List<Item> GetItems(){
        return new List<Item>(Items.Values);
    }

    public void RemoveItemAtIndex(int forIndex){
        if(Items[forIndex] == null) {
            throw new UnknownItemException(
                "Attempted to remove item from empty index `" + forIndex + "`"
            );
        }
        Destroy(Items[forIndex]);
        Items[forIndex] = null;
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
