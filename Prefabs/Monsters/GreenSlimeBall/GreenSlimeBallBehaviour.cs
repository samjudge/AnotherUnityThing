using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GreenSlimeBallBehaviour : MonoBehaviour
{
    [SerializeField]
    private Health Health;
    [SerializeField]
    private OnDamageEventEmitter OnDamageEmitter;
    [SerializeField]
    private OnLockEventEmitter LockOnEmitter;
    [SerializeField]
    private ScrollingFadingTextBehaviourFactory DamageTextFactory;
    [SerializeField]
    private GoapEventHandler GoapSystem;
    [SerializeField]
    private Rigidbody Body;
    [SerializeField]
    public MovableBody Movement;

    void Start(){
        GoapSystem.Events.Add(new GoapFunctionPair(
            WanderAroundScore,
            WanderAround
        ));
        GoapSystem.Events.Add(new GoapFunctionPair(
            ChasePlayerInLOSScore,
            ChasePlayerInLOS
        ));
    }
    
    void Update(){
    }

    //goap testing
    [SerializeField]
    private float MaxSpeed = 1f;
    [SerializeField]
    private float Acceleration = 1f;

    private uint WanderAroundScore(){
        return 1;
    }

    private void WanderAround(){
        Movement.Acceleration = Acceleration;
        Movement.MaxSpeed = MaxSpeed;
        Movement.Direction = (new Vector3(Dice.Roll(-100,100), 0 , Dice.Roll(-100,100))).normalized;
    }

    private float PlayerSearchRadiusUnits = 2f;
    private Vector3 LastSeenPlayerLocation;

    private uint ChasePlayerInLOSScore(){
        Collider[] collisions =
            Physics.OverlapSphere(this.transform.position, PlayerSearchRadiusUnits);
        uint score = 0;
        foreach(Collider c in collisions){
            if(c.GetComponent<PlayerMovementBehaviour>() != null){
                score = 2;
                LastSeenPlayerLocation = c.transform.position;
            }
        }
        return score;
    }

    private void ChasePlayerInLOS(){
        Movement.Acceleration = Acceleration;
        Movement.MaxSpeed = MaxSpeed;
        Movement.Direction = (LastSeenPlayerLocation - this.transform.position).normalized;
    }

    //health component + dtf component test

    public void TakeDamage(OnDamageRecievedEventData DamageData)
    {
        DamageTextFactory.Make("-" + DamageData.Damage.ToString());
        Health.TakeDamage(DamageData.Damage);
        if(Health.CurrentValue < 0) {
            LockOnEmitter.Emit(
                new OnLockReleaseEventData(
                    this.LockOnEmitter.LockOnSource
                )
            );
            Destroy(this.gameObject);
        }
    }

    public void LockAttained(){
        //show hp bar?
    }

    public void ReleaseLockOnDeath(OnLockReleaseEventData e){
        //hide hp bar?
        //remove the lock
        if(e.LockBehaviour != null){
            e.LockBehaviour.RemoveLock();
        }
    }
}
