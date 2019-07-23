using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnCastEventEmitter : MonoBehaviour {

    [SerializeField]
    private OnCastEventHandler Handler;

    public void Emit(OnPointTargetCastEventData e){
        Handler.OnPointTargetCast.Invoke(e);
    }

    public void Emit(OnLockedTargetCastEventData e){
        Handler.OnLockedTargetCast.Invoke(e);
    }
}
