using UnityEngine;

public class MagicMissileBehaviourFactory : MonoBehaviour
{
    [SerializeField]
    private MagicMissileBehaviour Prefab;

    public void Make(
        OnLockedTargetCastEventData e
    ){
        MagicMissileBehaviour Projectile =
            Instantiate(Prefab);
        Projectile.transform.position = e.Caster.transform.position;
        Projectile.EndTargetBody = e.LockedOnTarget.transform;
        Projectile.CreatorCollider = e.Caster.GetComponent<Collider>();
    }
}