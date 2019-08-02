using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class EnvenomSkill : MonoBehaviour
{
    [SerializeField]
    private Status PosionStatus;

    public void Cast(OnPointTargetCastEventData e) {
        StatusCollection StatusCollection =
            e.Caster.GetComponentInChildren<StatusCollection>();
        if(StatusCollection != null){
            Status PosionStatus = Instantiate(this.PosionStatus);
            StatusCollection.AddStatus(PosionStatus);
            PosionStatus.Emitter.Emit(
                new OnStatusStartEventData(e.Caster, gameObject, 3f)
            );
        }
    }
}