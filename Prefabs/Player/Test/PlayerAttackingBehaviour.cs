﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingBehaviour : MonoBehaviour {

    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private BasicProjectileBehaviourFactory BasicProjectileFactory;
    [SerializeField]
    private MagicMissileBehaviourFactory MagicMissile;
    [SerializeField]
    private PlayerLockOnBehaviour LockOnBehaviour;

    public void AttackByKeyEvent(OnKeyDownEventData e){
        switch(e.Key){
            case KeyCode.Mouse0 :
                if(LockOnBehaviour.LockedOntoBody != null) {
                    LaunchAttackToBody(LockOnBehaviour.LockedOntoBody);
                } else {
                    LaunchAttackToMousePoint();
                }
                break;
            case KeyCode.Mouse1 :
                if(LockOnBehaviour.LockedOntoBody != null) {
                    LaunchMagicMissileToBody(LockOnBehaviour.LockedOntoBody);
                } else {
                }
                break;
        }
    }

    public void LaunchMagicMissileToBody(Transform Body){
        MagicMissile.Make(Body);
    }

    private void LaunchAttackToBody(Transform Body){
        Vector3 direction = Body.position -
            transform.position;
        BasicProjectileFactory.Make(
            direction
        );
    }

    private void LaunchAttackToMousePoint(){ 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(
            new Vector3(0f, 1f, 0f),
            transform.position
        );
        float distance = 0f;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        Vector3 direction = point - transform.position;
        BasicProjectileFactory.Make(
            direction
        );
    }
}
