using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class OnKeyPressedEventData
{
    public KeyCode Key { get; private set; }
    public float duration;

    public OnKeyPressedEventData(KeyCode Key){
        this.Key = Key;
        this.duration = 0;
    }
}
