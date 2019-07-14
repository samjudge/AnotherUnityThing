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
    public LockOnable LockOnSource;

    public void Emit(OnLockAttainEventData e) {
        e.LockBehaviour = LockOnSource;
        Listener.OnLockAttain.Invoke(e);
    }

    public void Emit(OnLockReleaseEventData e) {
        e.LockBehaviour = LockOnSource;
        Listener.OnLockRelease.Invoke(e);
    }
}
