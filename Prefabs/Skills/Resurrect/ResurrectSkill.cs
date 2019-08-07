using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ResurrectSkill : MonoBehaviour
{
    public void Cast(OnLockedTargetCastEventData e) {
        OnResurrectEventEmitter emitter = e.LockedOnTarget.GetComponent<OnResurrectEventEmitter>();
        if(emitter != null) {
            emitter.Emit(new OnResurrectEventData(1f));
        }
    }
}