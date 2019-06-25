using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class KeyUpEventData
{
    public KeyCode Key { get; private set; }

    public KeyUpEventData(KeyCode Key){
        this.Key = Key;
    }
}
