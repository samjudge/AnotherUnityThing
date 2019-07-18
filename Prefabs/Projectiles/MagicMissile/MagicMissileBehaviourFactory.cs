using UnityEngine;

public class MagicMissileBehaviourFactory : MonoBehaviour
{
    [SerializeField]
    private MagicMissileBehaviour Prefab;
    [SerializeField]
    private Collider Owner;

    public MagicMissileBehaviour Make(
        Transform Target
    ){
        MagicMissileBehaviour Projectile =
            Instantiate(Prefab);
        Projectile.transform.position = transform.position;
        Projectile.EndTargetBody = Target;
        Projectile.CreatorCollider = Owner;
        return Projectile;
    }
}