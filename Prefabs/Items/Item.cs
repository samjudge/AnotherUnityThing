using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public Sprite UIItemImage;
    [SerializeField]
    public String Label;
    [SerializeField]
    public OnItemEventEmitter Emitter;
}
