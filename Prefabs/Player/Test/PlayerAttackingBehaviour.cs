using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingBehaviour : MonoBehaviour {

    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private BasicProjectileBehaviourFactory Factory;
    [SerializeField]
    private PlayerLockOnBehaviour PlayerLockOn;
    [SerializeField]
    private Rigidbody Body;

    public void AttackByKeyEvent(OnKeyDownEventData e){
        switch(e.Key){
           case KeyCode.Mouse0 :
                if(PlayerLockOn.IsLockedOn){
                    LaunchAttackToLockedOnTaret();
                } else {
                    LaunchAttackToMousePoint();
                }
                break;
        }
    }

    public void LaunchMagicMissileByMouseClick(OnMouseClickEventData e){

    }

    private void LaunchAttackToLockedOnTaret(){
        if(PlayerLockOn.LockedOnTransform != null){
            Vector3 direction = 
                PlayerLockOn.LockedOnTransform.position -
                transform.position;
            Factory.Make(
                direction
            );
        }
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
        Factory.Make(
            direction
        );
    }
}
