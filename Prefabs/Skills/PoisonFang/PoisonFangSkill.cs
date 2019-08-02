using UnityEngine;

public class PoisonFangSkill : MonoBehaviour
{
    [SerializeField]
    private PoisonFangBehaviour Prefab;

    public void Cast(
        OnLockedTargetCastEventData e
    ){
        PoisonFangBehaviour Projectile =
            Instantiate(Prefab);
        Projectile.transform.position = e.Caster.transform.position;
        Projectile.Caster = e.Caster.transform;
        Projectile.Target = e.LockedOnTarget;
    }
}