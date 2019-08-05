using UnityEngine;

public class MagicMissileBehaviour : MonoBehaviour
{

    public Collider CreatorCollider;
    public Transform EndTargetBody;
    [SerializeField]
    public OnCastEventEmitter Emitter;
    [SerializeField]
    public Skill Skill;
    [SerializeField]
    private float Lifetime = 3f;
    private float cLifetime = 0f;
    [SerializeField]
    private float Speed = 1f;
    [SerializeField]
    private float MinArcForce = 0.75f;
    [SerializeField]
    private float MaxArcForce = 1.25f;
    private Vector3 StartPos;
    private Vector3 ArcPeakPos;
    private Vector3 LastSeenPos;

    void Start(){
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
        //calculate direction
        Vector3 direction = (EndTargetBody.position - transform.position).normalized;
        //where the pathVector
        //is the total vector travelled as a straight line
        Vector3 pathVector = Speed * Lifetime * direction.normalized;
        //randomize arcPeak
        StartPos = this.transform.position;
        //where the arc peak is half way through the pathVector, with a raised peak
        ArcPeakPos = StartPos +
            pathVector / 2 +
            Quaternion.AngleAxis(
                Dice.Roll(0f,180f) - 90f,
                direction.normalized
            ) * new Vector3(0f, Dice.Roll(MinArcForce, MaxArcForce), 0f);
        LastSeenPos = EndTargetBody.transform.position;
    }

    void Update(){
        //update the position
        if(EndTargetBody != null) LastSeenPos = EndTargetBody.transform.position;
        transform.position = BezUtils.Bez3(
            StartPos,
            ArcPeakPos,
            LastSeenPos,
            cLifetime/Lifetime
        );
        //end attack if taking too long
        if(cLifetime > Lifetime){
            Emitter.Emit(
                new OnCastEndEventData(CreatorCollider.gameObject)
            );
        }
        //update the time delta
        cLifetime += Time.deltaTime;
    }

    public void OnTriggerEnter(Collider O){
        //only interact with damagables
        if (O.GetComponent<OnDamageEventHandler>() != null){
            Emitter.Emit(
                new OnCastHitTargetEventData(
                    CreatorCollider.gameObject,
                    O.gameObject
                )
            );
        }
    }

    public void OnCastLifecycleEnd(OnCastEndEventData e){
        Skill.GetEmitter().Emit(e);
        Destroy(gameObject);
    }

    public void OnProjectileHit(OnCastHitTargetEventData e){
        Skill.GetEmitter().Emit(e);
        OnDamageEventEmitter damageEmitter = e.With.GetComponent<OnDamageEventEmitter>();
        if(damageEmitter != null){
            damageEmitter.Emit(new OnDamageRecievedEventData(
                CreatorCollider.gameObject,
                69
            ));
            Emitter.Emit(new OnCastEndEventData(e.Caster));
        }
    }
}