using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnStatusEventEmitter : MonoBehaviour {

    [SerializeField]
    private OnStatusEventHandler Handler;

    public void Emit(OnStatusTickEventData e){
        Handler.OnStatusTick.Invoke(e);
    }

    public void Emit(OnStatusStartEventData e){
        Handler.OnStatusStart.Invoke(e);
    }

    public void Emit(OnStatusEndEventData e){
        Handler.OnStatusEnd.Invoke(e);
    }
}
