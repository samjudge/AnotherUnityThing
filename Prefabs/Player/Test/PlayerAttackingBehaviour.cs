using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingBehaviour : MonoBehaviour {

    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private BasicProjectileBehaviourFactory BasicProjectileFactory;
    [SerializeField]
    private PlayerLockOnBehaviour LockOnBehaviour;

    [SerializeField]
    private Skill[] Skills;

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
                    Skills[0].GetEmitter().Emit(
                        new OnPointTargetCastEventData(
                            gameObject,
                            MousePointToWorldPos(),
                            new Dictionary<string, float>
                            {
                                { "ChargeMaxSpeed", 5 },
                                { "ChargeMaxAcceleration", 400 }
                            }
                        )
                    );
                    //LaunchMagicMissileToBody(LockOnBehaviour.LockedOntoBody);
                } else {
                    Skills[0].GetEmitter().Emit(
                        new OnPointTargetCastEventData(
                            gameObject,
                            MousePointToWorldPos(),
                            new Dictionary<string, float>
                            {
                                { "ChargeMaxSpeed", 5 },
                                { "ChargeMaxAcceleration", 400 }
                            }
                        )
                    );
                }
                break;
        }
    }

    private void LaunchAttackToBody(Transform Body){
        Vector3 direction = Body.position -
            transform.position;
        BasicProjectileFactory.Make(
            direction
        );
    }

    private Vector3 MousePointToWorldPos(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(
            new Vector3(0f, 1f, 0f),
            transform.position
        );
        float distance = 0f;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        return point;
    }

    private void LaunchAttackToMousePoint(){ 
        Vector3 point = MousePointToWorldPos();
        Vector3 direction = point - transform.position;
        BasicProjectileFactory.Make(
            direction
        );
    }
}
