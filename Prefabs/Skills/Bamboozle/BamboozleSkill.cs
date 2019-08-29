using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class BamboozleSkill : MonoBehaviour
{
    [SerializeField]
    private Status ConfusionStatus;

    public void Cast(OnPointTargetCastEventData e) {
        StatusCollection statusCollection =
            e.Caster.GetComponentInChildren<StatusCollection>();
        if(statusCollection != null){
            Status confusionStatus = Instantiate(ConfusionStatus);
            statusCollection.AddStatus(confusionStatus);
            confusionStatus.Emitter.Emit(
                new OnStatusStartEventData(e.Caster, gameObject, 5f)
            );
        }
    }
}