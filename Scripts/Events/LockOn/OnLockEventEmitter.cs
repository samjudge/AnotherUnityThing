using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class OnLockEventEmitter : MonoBehaviour
{
    [SerializeField]
    private OnLockEventHandler Listener;

    public void Emit(OnLockAttainEventData e) {
        Listener.OnLockAttain.Invoke(e);
    }

    public void Emit(OnLockReleaseEventData e) {
        Listener.OnLockRelease.Invoke(e);
    }
}
