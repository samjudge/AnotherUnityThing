using UnityEngine;

public class OnCastHitTargetEventData
{
    public GameObject Caster;
    public GameObject With;

    public OnCastHitTargetEventData(GameObject caster, GameObject with) {
        Caster = caster;
        With = with;
    }
}