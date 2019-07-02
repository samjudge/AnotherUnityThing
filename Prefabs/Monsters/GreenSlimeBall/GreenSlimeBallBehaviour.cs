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
    private OnDamageEventEmitter Emitter;
    [SerializeField]
    private ScrollingFadingTextBehaviourFactory DamageTextFactory;
    [SerializeField]
    private GoapEventHandler GoapSystem;
    [SerializeField]
    private Rigidbody Body;

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
        cMoveTimer += Time.deltaTime;
    }

    //goap testing

    private float Speed = 10f;
    private float MoveTimer = 0.1f;
    private float cMoveTimer = 0f;
    
    private uint WanderAroundScore(){
        return 1;
    }

    private void WanderAround(){
        if(cMoveTimer >= MoveTimer) {
            cMoveTimer = 0f;
            Body.AddForce((new Vector3(Dice.Roll(-100,100), 0 , Dice.Roll(-100,100))).normalized * Speed);
        }
    }

    private float PlayerSearchRadiusUnits = 1f;
    private Vector3 LastSeenPlayerLocation;

    private uint ChasePlayerInLOSScore(){
        Collider[] collisions =
            Physics.OverlapSphere(this.transform.position, PlayerSearchRadiusUnits);
        uint score = 0;
        foreach(Collider c in collisions){
            if(c.GetComponent<PlayerAttackingBehaviour>() != null){
                score = 2;
                LastSeenPlayerLocation = c.transform.position;
            }
        }
        return score;
    }

    private void ChasePlayerInLOS(){
        if(cMoveTimer >= MoveTimer) {
            cMoveTimer = 0f;
            Body.AddForce((LastSeenPlayerLocation - this.transform.position).normalized * Speed);
        }
    }

    //health component + dtf component test

    public void TakeDamage(OnDamageRecievedEventData DamageData)
    {
        DamageTextFactory.Make("-" + DamageData.Damage.ToString());
        Health.TakeDamage(DamageData.Damage);
        if(Health.CurrentValue < 0) {
            Destroy(this.gameObject);
        }
    }
}
