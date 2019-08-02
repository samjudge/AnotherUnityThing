using UnityEngine;

public class MagicMissileSkill : MonoBehaviour
{
    [SerializeField]
    private MagicMissileBehaviour Prefab;

    public void Cast(
        OnLockedTargetCastEventData e
    ){
        MagicMissileBehaviour Projectile =
            Instantiate(Prefab);
        Projectile.transform.position = e.Caster.transform.position;
        Projectile.EndTargetBody = e.LockedOnTarget.transform;
        Projectile.CreatorCollider = e.Caster.GetComponent<Collider>();
    }
}