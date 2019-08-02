using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnStatusEventHandler : MonoBehaviour {
    [SerializeField]
    public OnStatusStartEvent OnStatusStart;
    [SerializeField]
    public OnStatusTickEvent OnStatusTick;
    [SerializeField]
    public OnStatusEndEvent OnStatusEnd;
}
