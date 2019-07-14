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
    public float ProjectileSpeed = 1f;
    [SerializeField]
    public float Lifespan = 1f;
    private float cLifespan = 0f;
    [SerializeField]
    public Collider CreatorCollider;
    [SerializeField]
    public OnAttackEventEmitter Emitter;
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
        Emitter.Emit(
            new OnAttackLaunchEventData()
        );
    }

    public void Update(){
        if(cLifespan > Lifespan){
            Emitter.Emit(
                new OnAttackEndEventData()
            );
        }
        cLifespan += Time.deltaTime;
        this.transform.position = this.transform.position + (Direction.normalized * Time.deltaTime * ProjectileSpeed);
    }

    public void OnTriggerEnter(Collider O){
        //only interact with damagables
        if (O.GetComponent<OnDamageEventHandler>() != null){
            Emitter.Emit(
                new OnAttackConnectEventData(O.gameObject, 25)
            );
            Emitter.Emit(
                new OnAttackEndEventData()
            );
        }
    }

    public void HitEnemy(OnAttackConnectEventData e){
        OnDamageEventEmitter targetEmitter = e.With.GetComponent<OnDamageEventEmitter>();
        if(targetEmitter != null){
            targetEmitter.Emit(new OnDamageRecievedEventData(e.Damage));
        }
    }

    public void EndProjectileAttack(OnAttackEndEventData e){
        Destroy(this.gameObject);
    }
}