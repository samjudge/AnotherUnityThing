using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class KeyDownEventData
{
    public KeyCode Key { get; private set; }

    public KeyDownEventData(KeyCode Key){
        this.Key = Key;
    }
}
