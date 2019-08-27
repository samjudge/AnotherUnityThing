using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnInventoryEventEmitter : MonoBehaviour {

    [SerializeField]
    private OnInventoryEventHandler Handler;

    public void Emit(OnInventoryAddEventData e){
        Handler.OnInventoryAddEvent.Invoke(e);
    }
}
