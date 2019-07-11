using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class OnMouseEventEmitter : MonoBehaviour
{
    [SerializeField]
    private OnMouseEventHandler Listener;

    public void Emit(OnMouseClickEventData e) {
        Listener.OnMouseClick.Invoke(e);
    }

    public void Emit(OnMouseMoveEventData e) {
        Listener.OnMouseMove.Invoke(e);
    }
}
