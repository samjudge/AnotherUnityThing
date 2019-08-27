using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinSpearmanCorpseBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject ResurrectAs;
    [SerializeField]
    private Image LockOnReticule;
    [SerializeField]
    private OnLockEventEmitter LockEmitter;

    public void OnResurrect(OnResurrectEventData e){
        //create a zombie goblin spearman and destroy the corpse
        GameObject g = Instantiate(ResurrectAs);
        g.transform.position = transform.position;
        LockEmitter.Emit(
            new OnLockReleaseEventData()
        );
        Destroy(gameObject);
    }

    public void LockAttained(OnLockAttainEventData e){
        LockOnReticule.enabled = true;
    }

    public void ReleaseLockOnDeath(OnLockReleaseEventData e){
        LockOnReticule.enabled = false;
    }
}
