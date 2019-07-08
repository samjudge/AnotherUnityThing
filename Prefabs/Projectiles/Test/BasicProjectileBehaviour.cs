using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BasicProjectileBehaviour : MonoBehaviour
{
    [SerializeField]
    public Vector3 Direction = new Vector3(1,0,0);
    [SerializeField]
    public float Lifespan = 1f;
    private float cLifespan = 0f;
    [SerializeField]
    public Collider CreatorCollider;
    [SerializeField]
    public AttackEventEmitter Emitter;
    [SerializeField]
    public Billboard RenderableBody;

    public void Awake(){}

    public void Start(){
        if(CreatorCollider == null){
            Debug.LogWarning(
                "BasicProjectileBehaviour ->\n" +
                "No CreatorCollider Set ->\n" +
                "May Collide With Creating Object"
            );
        } else {
            //make sure it doesn't affect the creating object
            Physics.IgnoreCollision(GetComponent<Collider>(), CreatorCollider);
        }
        Emitter.emit(
            new AttackLaunchEventData()
        );
    }

    public void Update(){
        if(cLifespan > Lifespan){
            Emitter.emit(
                new AttackEndEventData()
            );
        }
        cLifespan += Time.deltaTime;
        this.transform.position = this.transform.position + (Direction.normalized * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider O){
        //only interact with damagables
        if (O.GetComponent<OnDamageEventHandler>() != null){
            Emitter.emit(
                new AttackConnectEventData(O.gameObject, 25)
            );
            Emitter.emit(
                new AttackEndEventData()
            );
        }
    }

    public void HitEnemy(AttackConnectEventData e){
        OnDamageEventEmitter targetEmitter = e.With.GetComponent<OnDamageEventEmitter>();
        if(targetEmitter != null){
            targetEmitter.emit(new OnDamageRecievedEventData(e.Damage));
        }
    }

    public void EndProjectileAttack(AttackEndEventData e){
        Destroy(this.gameObject);
    }
}