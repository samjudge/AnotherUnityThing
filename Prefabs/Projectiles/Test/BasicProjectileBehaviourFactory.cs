using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BasicProjectileBehaviourFactory : MonoBehaviour
{
    [SerializeField]
    private BasicProjectileBehaviour Prefab;
    [SerializeField]
    public Collider Owner;
    [SerializeField]
    public float Lifespan;
    [SerializeField]
    public Camera Face;

    public BasicProjectileBehaviour Make(
        Vector3 Direction
    ){
        BasicProjectileBehaviour Projectile =
            Instantiate(Prefab);
        Projectile.transform.position = transform.position;
        Projectile.CreatorCollider = Owner;
        Projectile.Direction = Direction;
        Projectile.Lifespan = Lifespan;
        Projectile.RenderableBody.SetFace(Face);
        return Projectile;
    }
}