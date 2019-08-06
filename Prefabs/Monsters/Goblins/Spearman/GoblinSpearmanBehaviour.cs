using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinSpearmanBehaviour : MonoBehaviour
{
    [SerializeField]
    private GoapEventHandler GoapSystem;
    [SerializeField]
    private MovableBody Movement;
    [SerializeField]
    private Image LockOnReticule;

    // Start is called before the first frame update
    void Start() { }

    public void LockAttained(OnLockAttainEventData e){
        LockOnReticule.enabled = true;
    }

    public void ReleaseLockOnDeath(OnLockReleaseEventData e){
        LockOnReticule.enabled = false;
    }
}
