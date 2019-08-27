using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnItemEventEmitter : MonoBehaviour {

    [SerializeField]
    private OnItemEventHandler Handler;

    public void Emit(OnItemUseEventData e){
        Handler.OnItemUseEvent.Invoke(e);
    }

    public void Emit(OnItemCollectEventData e){
        Handler.OnItemCollectEvent.Invoke(e);
    }
}
