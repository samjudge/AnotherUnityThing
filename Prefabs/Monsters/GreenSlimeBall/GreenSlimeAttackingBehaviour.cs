using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GreenSlimeAttackingBehaviour : MonoBehaviour
{
    [SerializeField]
    private GoapEventHandler GoapSystem;
    [SerializeField]
    private Rigidbody Body;
    [SerializeField]
    private ScrollingFadingTextBehaviourFactory Text;
    [SerializeField]
    private GreenSlimeBallBehaviour Slime;
    [SerializeField]
    private MovableBody Movement;
    [SerializeField]
    private SkillCollection Skills;
    [SerializeField]
    private Status PoisonStatusPrefab;

    void Start(){
        GoapSystem.Events.Add(
            new GoapFunctionPair(
                AttackPlayerWhenClose,
                LaunchAttack
            )
        );
        Skills.GetSkills()[1]
            .GetEmitter()
            .Emit(new OnPassiveCastEventData(Slime.gameObject));
        Skills.GetSkills()[0]
            .GetHandler()
            .OnEndCast
            .AddListener(AttackEnd);
        Skills.GetSkills()[0]
            .GetHandler()
            .OnCastHitTarget
            .AddListener(AttackConnect);
    }
    
    void Update(){ }

    private float PlayerAttackRadiusUnits = 1.5f;
    private float AttackTimer = 2f;
    private float cAttackTimer = 0f;
    private Vector3 LastSeenPlayerLocation;
    private bool AttackInProgress = false;
    private bool DidAttackHit = false;

    private uint AttackPlayerWhenClose() {
        if(AttackInProgress) {
            return 3;
        }
        cAttackTimer += Time.deltaTime;
        if(cAttackTimer > AttackTimer) {
            Collider[] collisions =
                Physics.OverlapSphere(this.transform.position, PlayerAttackRadiusUnits);
            foreach(Collider c in collisions) {
                if(c.GetComponent<PlayerAttackedBehaviour>() != null) {
                    LastSeenPlayerLocation = c.transform.position;
                    return 3;
                }
            }
        }
        return 0;
    }

    public void LaunchAttack() {
        if(!AttackInProgress) {
            cAttackTimer = 0f;
            AttackInProgress = true;
            DidAttackHit = false;
            Skills.GetSkills()[0].GetEmitter().Emit(
                new OnPointTargetCastEventData(
                    Slime.gameObject,
                    LastSeenPlayerLocation,
                    new StatCollection(
                        new KeyValuePair<string, float>(
                            "ChargeMaxSpeed", 0
                        ),
                        new KeyValuePair<string, float>(
                            "ChargeMaxAcceleration", 0
                        ),
                        new KeyValuePair<string, float>(
                            "ChargeDuration", 0.5f
                        )
                    )
                )
            );
        }
    }

    public void AttackConnect(OnCastHitTargetEventData e) {
        Text.Make("Hit!");
        DidAttackHit = true;
    }

    public void AttackEnd(OnCastEndEventData e) {
        AttackInProgress = false;
        if(!DidAttackHit) {
            Text.Make("Miss!");
        }
    }
}
