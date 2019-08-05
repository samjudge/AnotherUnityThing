using System.Collections;
using UnityEngine;

public class PoisonFangBehaviour : MonoBehaviour
{

    [SerializeField]
    public Skill Skill;
    [SerializeField]
    public OnCastEventEmitter Emitter;
    public Transform Caster;
    public GameObject Target;
    [SerializeField]
    private Status StatusPrefab;
    [SerializeField]
    private Transform FangA;
    [SerializeField]
    private Transform FangB;
    [SerializeField]
    private float Lifetime;
    private float cLifetime;
    private bool hasHit;

    void Start(){ }

    void Update(){
        //early exit
        if(hasHit) return;
        if(Target == null) Emitter.Emit(new OnCastEndEventData(Caster.gameObject));
        //update this position
        transform.position = Vector3.Lerp(
            Caster.position,
            Target.transform.position,
            cLifetime / Lifetime
        );
        //update the fang a position
        FangA.localPosition = BezUtils.Bez3(
            Vector3.zero,
            new Vector3(2.5f,2.5f,0f),
            Vector3.zero,
            cLifetime / Lifetime
        );
        //update the fang b position
        FangB.localPosition = BezUtils.Bez3(
            Vector3.zero,
            new Vector3(-2.5f,2.5f,0f),
            Vector3.zero,
            cLifetime / Lifetime
        );
        //update clock
        cLifetime += Time.deltaTime;
        if(cLifetime > Lifetime) {
            Emitter.Emit(new OnCastEndEventData(Caster.gameObject));
        }
    }

    public void OnTriggerEnter(Collider O){
        //only interact with damagables
        if (O.GetComponentInChildren<StatusCollection>() != null){
            if(O.gameObject == Caster.gameObject) return; //dont collider with self
            if(O.gameObject.layer == Caster.gameObject.layer) return; //dont collide with shared tags as caster
            Emitter.Emit(new OnCastHitTargetEventData(
                Caster.gameObject,
                O.gameObject
            ));
        }
    }

    public void HitTarget(OnCastHitTargetEventData e){
        Skill.GetEmitter().Emit(e);
        StatusCollection StatusCollection =
            e.With.GetComponentInChildren<StatusCollection>();
        Status PosionStatus = Instantiate(StatusPrefab);
        StatusCollection.AddStatus(
            PosionStatus
        );
        hasHit = true;
        PosionStatus.Emitter.Emit(
            new OnStatusStartEventData(e.With.gameObject, gameObject, 3f)
        );
        StartCoroutine(DestroyAfter(1f));
    }

    public IEnumerator DestroyAfter(float s) {
        ParticleSystem.EmissionModule ParticleEmission = FangA.GetComponent<ParticleSystem>().emission;
        ParticleEmission.enabled = false;
        ParticleEmission = FangB.GetComponent<ParticleSystem>().emission;
        ParticleEmission.enabled = false;
        yield return new WaitForSeconds(s);
        Emitter.Emit(
           new OnCastEndEventData(Caster.gameObject)
        );
    }

    public void LifecycleEnd(OnCastEndEventData e){
        Skill.GetEmitter().Emit(e);
        Destroy(gameObject);
    }
}