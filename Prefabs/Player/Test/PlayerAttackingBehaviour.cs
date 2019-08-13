﻿using System.Collections;
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
    private SkillCollection Skills;
    [SerializeField]
    private ItemCollection Items;

    public void AttackByKeyEvent(OnKeyDownEventData e){
        switch(e.Key){
            case KeyCode.Mouse0 :
                if(LockOnBehaviour.LockedOntoBody != null) {
                    LaunchAttackToBody(LockOnBehaviour.LockedOntoBody);
                } else {
                    LaunchAttackToMousePoint();
                }
                break;
            case KeyCode.Alpha1:
                CastSpell(0);
                break;
            case KeyCode.Alpha2:
                CastSpell(1);
                break;
            case KeyCode.Alpha3:
                CastSpell(2);
                break;
            case KeyCode.Alpha4:
                CastSpell(3);
                break;
            case KeyCode.Alpha5:
                CastSpell(4);
                break;
            case KeyCode.F1:
                Items.GetItemAtIndex(0).Emitter.Emit(
                    new OnItemUseEventData(gameObject)
                );
                break;
        }
    }

    public void CastSpell(int index){
        if(LockOnBehaviour.LockedOntoBody != null) {
            Skills.GetSkills()[index].GetEmitter().Emit(
                new OnPointTargetCastEventData(
                    gameObject,
                    LockOnBehaviour.LockedOntoBody.position,
                    new StatCollection(
                        new KeyValuePair<string, float>(
                            "ChargeDuration", 2
                        )
                    )
                )
            );
            Skills.GetSkills()[index].GetEmitter().Emit(
                new OnLockedTargetCastEventData(
                    LockOnBehaviour.LockedOntoBody.gameObject,
                    gameObject
                )
            );
        } else {
            Skills.GetSkills()[index].GetEmitter().Emit(
                new OnPointTargetCastEventData(
                    gameObject,
                    MousePointToWorldPos(),
                    new StatCollection(
                        new KeyValuePair<string, float>(
                            "ChargeDuration", 2
                        )
                    )
                )
            );
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
