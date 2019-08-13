using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public Sprite UISkillImage;
    [SerializeField]
    public String Label;
    [SerializeField]
    public OnItemEventEmitter Emitter;
}
