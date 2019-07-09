using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class OnKeyUpEventData
{
    public KeyCode Key { get; private set; }

    public OnKeyUpEventData(KeyCode Key){
        this.Key = Key;
    }
}
