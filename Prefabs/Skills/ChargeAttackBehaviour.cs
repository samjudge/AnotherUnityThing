using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class ChargeAttackBehaviour : MonoBehaviour
{
    private static float MovementWeighting = 100f;

    public void Charge(OnPointTargetCastEventData e){
        ColorShifter colorShifter = e.Caster.GetComponentInChildren<ColorShifter>();
        MovableBody movableBody = e.Caster.GetComponentInChildren<MovableBody>();
        OnAttackEventEmitter onAttackEventEmitter = e.Caster.GetComponentInChildren<OnAttackEventEmitter>();
        OnAttackEventHandler onAttackEventHandler = e.Caster.GetComponentInChildren<OnAttackEventHandler>();
        StartCharging(
            colorShifter,
            movableBody,
            onAttackEventEmitter,
            onAttackEventHandler,
            e.Stats["ChargeMaxSpeed"],
            e.Stats["ChargeMaxAcceleration"],
            e.Target,
            e.Caster.gameObject.transform.position,
            0.25f
        );
    }

    public void StartCharging(
        ColorShifter colorShifter,
        MovableBody movement,
        OnAttackEventEmitter attackEventEmitter,
        OnAttackEventHandler attackEventHandler,
        float bonusSpeed,
        float bonusAcceleration,
        Vector3 target,
        Vector3 originPosition,
        float duration
    ){
        if(colorShifter != null){
            colorShifter.ShiftToColor(new Color(1f,1f,1f), new Color(1f,0f,0f), duration / 4f);
        }
        Vector3 direction = (target - originPosition).normalized;
        if(attackEventEmitter != null){
            attackEventEmitter.Emit(new OnAttackLaunchEventData());
            UnityAction<OnAttackEndEventData> e = null;
            e = delegate (OnAttackEndEventData data) {
                StopCharging(
                    duration / 4f,
                    direction,
                    bonusSpeed,
                    bonusAcceleration,
                    colorShifter,
                    movement,
                    attackEventEmitter,
                    attackEventHandler,
                    e //trust me on this haha
                );
            };
            attackEventHandler.OnAttackEnd.AddListener(e);
            movement.StartCoroutine(EndAfter(
                duration,
                attackEventEmitter
            ));
            movement.SetMaxSpeed(movement.GetMaxSpeed() + bonusSpeed);
            movement.SetAcceleration(movement.GetAcceleration() + bonusAcceleration);
            movement.AddToDirection(direction, MovementWeighting);
        }
    }

    private IEnumerator EndAfter(
        float seconds,
        OnAttackEventEmitter attackEventEmitter
    ){
        yield return new WaitForSeconds(seconds);
        attackEventEmitter.Emit(new OnAttackEndEventData());
    }

    private void StopCharging(
        float colorChangeDuration,
        Vector3 directionUnshift,
        float bonusSpeed,
        float bonusAcceleration,
        ColorShifter colorShifter,
        MovableBody movement,
        OnAttackEventEmitter attackEventEmitter,
        OnAttackEventHandler attackEventHandler,
        UnityAction<OnAttackEndEventData> eventRef
    ){
        if(attackEventEmitter != null){
            attackEventHandler.OnAttackEnd.RemoveListener(eventRef); //such that this delegate
                                                                     //won't be called again
        }
        if(colorShifter != null){
            colorShifter.ShiftToColor(new Color(1f,0f,0f), new Color(1f,1f,1f), colorChangeDuration);
        }
        movement.SetMaxSpeed(movement.GetMaxSpeed() - bonusSpeed);
        movement.SetAcceleration(movement.GetAcceleration() - bonusAcceleration);
        movement.AddToDirection(directionUnshift, -MovementWeighting);
    }
}