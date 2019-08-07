using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinShamanResurrectAlliesBehaviour : MonoBehaviour
{
    [SerializeField]
    private GoapEventHandler GoapSystem;
    [SerializeField]
    private SkillCollection Skills;
    private GoblinSpearmanCorpseBehaviour nearestCorpse;

    void Start() {
        GoapSystem.Events.Add(new GoapFunctionPair(
            ShouldResurrectFallen,
            ResurrectFallen
        ));
    }

    private uint ShouldResurrectFallen() {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            2f
        );
        foreach(Collider hit in hits){
            GoblinSpearmanCorpseBehaviour corpse = hit.GetComponent<GoblinSpearmanCorpseBehaviour>();
            if(corpse != null) {
                nearestCorpse = corpse;
                return 1000;
            }
        }
        return 1;
    }

    private void ResurrectFallen() {
        if(nearestCorpse == null) return;
        Skill s = Skills.GetNamedSkill("resurrect");
        s.GetEmitter().Emit(
            new OnLockedTargetCastEventData(
                nearestCorpse.gameObject,
                gameObject
            )
        );
    }
}
