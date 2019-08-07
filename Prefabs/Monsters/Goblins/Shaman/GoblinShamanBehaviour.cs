using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinShamanBehaviour : MonoBehaviour
{
    [SerializeField]
    private GoapEventHandler GoapSystem;
    [SerializeField]
    private MovableBody Movement;
    [SerializeField]
    private Image LockOnReticule;
    [SerializeField]
    private Health Health;
    [SerializeField]
    private OnLockEventEmitter LockOnEmitter;
    [SerializeField]
    private ScrollingFadingTextBehaviourFactory DamageTextFactory;

    void Start() { }
    
    public void TakeDamage(OnDamageRecievedEventData DamageData)
    {
        DamageTextFactory.Make("-" + DamageData.Damage.ToString());
        Health.TakeDamage(DamageData.Damage);
        if(Health.CurrentValue < 0) {
            LockOnEmitter.Emit(new OnLockReleaseEventData());
            Destroy(this.gameObject);
        }
    }

    public void LockAttained(OnLockAttainEventData e){
        LockOnReticule.enabled = true;
    }

    public void ReleaseLockOnDeath(OnLockReleaseEventData e){
        LockOnReticule.enabled = false;
    }

}
