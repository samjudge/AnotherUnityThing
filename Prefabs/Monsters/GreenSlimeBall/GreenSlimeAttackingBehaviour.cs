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
    private float AttackMaxSpeed;
    [SerializeField]
    private float AttackMaxAcceleration;
    [SerializeField]
    private float AttackDurationTimer = 1.5f;
    private float cAttackDurationTimer;
    [SerializeField]
    private ColorShifter ColorShifter;
    [SerializeField]
    private ScrollingFadingTextBehaviourFactory Text;
    [SerializeField]
    private GreenSlimeBallBehaviour Slime;
    [SerializeField]
    private MovableBody Movement;


    void Start(){
        GoapSystem.Events.Add(
            new GoapFunctionPair(
                AttackPlayerWhenClose,
                LaunchAttack
            )
        );
    }
    
    void Update(){
        if(cAttackDurationTimer < AttackDurationTimer && AttackInProgress){
            cAttackDurationTimer += Time.deltaTime;
        }
        if(cAttackDurationTimer >= AttackDurationTimer && AttackInProgress){
            Text.Make("Miss!");
            Emitter.Emit(
                new OnAttackEndEventData()
            );
        }
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
    private float AttackTimer = 5f;
    private float cAttackTimer = 0f;
    private Vector3 LastSeenPlayerLocation;
    private bool AttackInProgress = false;

    private uint AttackPlayerWhenClose(){
        if(AttackInProgress) return 3;
        cAttackTimer += Time.deltaTime;
        if(cAttackTimer > AttackTimer) {
            Collider[] collisions =
                Physics.OverlapSphere(this.transform.position, PlayerAttackRadiusUnits);
            foreach(Collider c in collisions){
                if(c.GetComponent<PlayerAttackedBehaviour>() != null){
                    LastSeenPlayerLocation = c.transform.position;
                    return 3;
                }
            }
        }
        return 0;
    }

    public void LaunchAttack(){
        if(!AttackInProgress) {
            Emitter.Emit(
                new OnAttackLaunchEventData()
            );
        }
    }

    public void StartAttack(){
        AttackInProgress = true;
        ColorShifter.ShiftToColor(new Color(1f,1f,1f), new Color(1f,0f,0f), 0.5f);
        cAttackTimer = 0f;
        cAttackDurationTimer = 0f;
        Movement.MaxSpeed = AttackMaxSpeed;
        Movement.Acceleration = AttackMaxAcceleration;
        Movement.Direction = (LastSeenPlayerLocation - this.transform.position).normalized * AttackMaxAcceleration;
    }

    public void EndAttack(){
        AttackInProgress = false;
        ColorShifter.ShiftToColor(new Color(1f,0f,0f), new Color(1f,1f,1f), 0.5f);
    }

    public void DamagePlayer(OnAttackConnectEventData e){
        Text.Make("Hit!");
        e.With.GetComponent<OnDamageEventEmitter>().Emit(
            new OnDamageRecievedEventData(e.Damage)
        );
    }
}
