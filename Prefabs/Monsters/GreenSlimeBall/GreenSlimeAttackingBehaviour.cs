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
    private OnAttackEventEmitter Emitter;
    [SerializeField]
    private Rigidbody Body;
    [SerializeField]
    private ScrollingFadingTextBehaviourFactory Text;
    [SerializeField]
    private GreenSlimeBallBehaviour Slime;
    [SerializeField]
    private MovableBody Movement;
    [SerializeField]
    private Skill[] Skills;

    void Start(){
        GoapSystem.Events.Add(
            new GoapFunctionPair(
                AttackPlayerWhenClose,
                LaunchAttack
            )
        );
    }
    
    void Update(){
        //if(cAttackDurationTimer >= AttackDurationTimer && AttackInProgress){
        //
        
        //    Emitter.Emit(
        //        new OnAttackEndEventData()
        //    );
        //}
    }

    public void OnTriggerEnter(Collider O){
        EmitAttackToCollidingPlayer(O);
    }

    public void OnTriggerStay(Collider O){
        EmitAttackToCollidingPlayer(O);
    }

    public void EmitAttackToCollidingPlayer(Collider collider){
        PlayerAttackedBehaviour Player = collider.GetComponent<PlayerAttackedBehaviour>();
        if(Player != null && AttackInProgress) {
            Emitter.Emit(
                new OnAttackConnectEventData(collider.gameObject, 25)
            );
            Emitter.Emit(
                new OnAttackEndEventData()
            );
        }
    }

    private float PlayerAttackRadiusUnits = 1.5f;
    private float AttackTimer = 2f;
    private float cAttackTimer = 0f;
    private Vector3 LastSeenPlayerLocation;
    private bool AttackInProgress = false;
    private bool DidAttackHit = false;

    private uint AttackPlayerWhenClose() {
        if(AttackInProgress) return 3;
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
            Skills[0].GetEmitter().Emit(
                new OnPointTargetCastEventData(
                    Slime.gameObject,
                    LastSeenPlayerLocation,
                    new Dictionary<string, float>
                    {
                        { "ChargeMaxSpeed", 2 },
                        { "ChargeMaxAcceleration", 5 }
                    }
                )
            );
        }
    }

    public void EndAttack() {
        AttackInProgress = false;
        if(!DidAttackHit) {
            Text.Make("Miss!");
        }
    }

    public void DamagePlayer(OnAttackConnectEventData e) {
        DidAttackHit = true;
        Text.Make("Hit!");
        e.With.GetComponent<OnDamageEventEmitter>().Emit(
            new OnDamageRecievedEventData(e.Damage)
        );
    }
}
