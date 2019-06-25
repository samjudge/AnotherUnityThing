using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class KeyPressedEventData
{
    public KeyCode Key { get; private set; }
    public float duration;

    public KeyPressedEventData(KeyCode Key){
        this.Key = Key;
        this.duration = 0;
    }
}
