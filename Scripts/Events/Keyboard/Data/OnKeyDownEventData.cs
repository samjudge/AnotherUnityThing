using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class OnKeyDownEventData
{
    public KeyCode Key { get; private set; }

    public OnKeyDownEventData(KeyCode Key){
        this.Key = Key;
    }
}
