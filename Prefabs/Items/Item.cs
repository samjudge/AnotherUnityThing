using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemTag { Weapon, Armour, Consumable, Misc }

    [SerializeField]
    public Sprite UIItemImage;
    [SerializeField]
    public String Label;
    [SerializeField]
    public OnItemEventEmitter Emitter;
    [SerializeField]
    public OnUIItemEventEmitter UIEmitter;
    [SerializeField]
    public ItemTag Category;
}
