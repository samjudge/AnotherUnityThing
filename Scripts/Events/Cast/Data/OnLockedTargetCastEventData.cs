using UnityEngine;

public class OnLockedTargetCastEventData
{
    public GameObject LockedOnTarget;
    public GameObject Caster;

    public OnLockedTargetCastEventData(
        GameObject LockedOnTarget,
        GameObject Caster
    ){
        this.LockedOnTarget = LockedOnTarget;
        this.Caster = Caster;
    }
}