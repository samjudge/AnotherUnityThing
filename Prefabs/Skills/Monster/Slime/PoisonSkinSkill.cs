using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PoisonSkinSkill : MonoBehaviour
{
    [SerializeField]
    private Status PosionStatus;
    private bool HasAlreadyAppliedEffect = false;

    public void TickPassive(OnPassiveCastEventData e) {
        //early exit
        if(HasAlreadyAppliedEffect) return;
        SkillCollection SkillCollection = 
            e.Caster.GetComponentInChildren<SkillCollection>();
        if(SkillCollection != null) { 
            Skill Charge = SkillCollection.GetNamedSkill("charge");
            Charge.GetHandler().OnCastHitTarget.AddListener(
                OnCastHit
            );
        }
        HasAlreadyAppliedEffect = true;
        //do not retick
    }

    private void OnCastHit(OnCastHitTargetEventData e) {
        StatusCollection StatusCollection =
            e.With.GetComponentInChildren<StatusCollection>();
        if(e.With == e.Caster.gameObject) return; //dont collider with self
        if(e.With.layer == e.Caster.layer) return; //dont collide with shared tags as caster
        if(StatusCollection != null){
            Status PosionStatus = Instantiate(this.PosionStatus);
            StatusCollection.AddStatus(PosionStatus);
            PosionStatus.Emitter.Emit(
                new OnStatusStartEventData(e.With, gameObject, 3f)
            );
        }
    }
}