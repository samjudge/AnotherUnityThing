using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class OnResurrectEventEmitter : MonoBehaviour
{
    [SerializeField]
    private OnResurrectEventHandler Listener;

    public void Emit(OnResurrectEventData e) {
        Listener.OnLockAttain.Invoke(e);
    }
}
