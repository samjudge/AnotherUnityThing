using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class ChargeAttackSkill : MonoBehaviour
{
    private float MovementWeighting = 100f;
    private bool IsCharging = false;
    private OnAttackEventHandler OnAttackEventHandler;
    private OnAttackEventEmitter OnAttackEventEmitter;
    private GameObject Caster;

    public void CancelCharge(OnCancelCastData e){
        IsCharging = false;
    }

    public void DamageTarget(OnAttackConnectEventData e){
        OnDamageEventEmitter Emitter = e.With.GetComponent<OnDamageEventEmitter>();
        if(Emitter != null){
            Emitter.Emit(new OnDamageRecievedEventData(e.Damage));
        }
    }

    public void Charge(OnPointTargetCastEventData e){
        Caster = e.Caster;
        OnAttackEventHandler = Caster.GetComponentInChildren<OnAttackEventHandler>();
        OnAttackEventEmitter = Caster.GetComponentInChildren<OnAttackEventEmitter>();
        ColorShifter colorShifter = Caster.GetComponentInChildren<ColorShifter>();
        MovableBody movableBody = Caster.GetComponentInChildren<MovableBody>();
        if(colorShifter == null) {
            Debug.LogWarning("No `ColorShifter` shifter component found when attempting to use charge skill");
        }
        if(movableBody == null){
            throw new MissingComponentException(
                "No `MovableBody` component found on caster when attempting to use charge skill"
            );
        }
        StartCharging(
            e.Stats.GetValue("ChargeDuraion", 0.33f),
            colorShifter,
            movableBody,
            e.Stats.GetValue("ChargeBonusSpeed", 2),
            e.Stats.GetValue("ChargeBonusAcceleration", 10),
            e.Target,
            e.Caster.gameObject.transform.position
        );
    }

    public void StartCharging(
        float duration,
        ColorShifter colorShifter,
        MovableBody movement,
        float bonusSpeed,
        float bonusAcceleration,
        Vector3 target,
        Vector3 originPosition
    ){
        IsCharging = true;
        OnAttackEventHandler.OnAttackConnect.AddListener(DamageTarget);
        if(colorShifter != null){
            colorShifter.ShiftToColor(new Color(1f,1f,1f), new Color(1f,0f,0f), duration / 4f);
        }
        Vector3 direction = (target - originPosition).normalized;
        StartCoroutine(EndAfter(
            duration,
            colorShifter,
            movement,
            bonusSpeed,
            bonusAcceleration,
            direction
        ));
        movement.SetMaxSpeed(movement.GetMaxSpeed() + bonusSpeed);
        movement.SetAcceleration(movement.GetAcceleration() + bonusAcceleration);
        movement.AddToDirection(direction, MovementWeighting);
    }

    private IEnumerator EndAfter(
        float duration,
        ColorShifter colorShifter,
        MovableBody movement,
        float bonusSpeed,
        float bonusAcceleration,
        Vector3 directionUnshift
    ){
        float timer = 0;
        while(timer < duration && IsCharging == true) {
            timer += Time.deltaTime;
            Collider[] collisions = Physics.OverlapSphere(Caster.transform.position, 0.25f);
            foreach(Collider collision in collisions){
                if(collision.gameObject == Caster.gameObject) continue; //dont collider with self
                if(collision.GetComponent<OnDamageEventEmitter>() != null)
                {
                    OnAttackEventEmitter.Emit(new OnAttackConnectEventData(
                        collision.gameObject,
                        25f //this should come from passed in stats
                    ));
                    IsCharging = false;
                }
            }
            yield return null;
        }
        IsCharging = false;
        OnAttackEventHandler.OnAttackConnect.RemoveListener(DamageTarget);
        movement.SetMaxSpeed(movement.GetMaxSpeed() - bonusSpeed);
        movement.SetAcceleration(movement.GetAcceleration() - bonusAcceleration);
        movement.AddToDirection(directionUnshift, -MovementWeighting);
        if(colorShifter != null) {
            colorShifter.ShiftToColor(new Color(1f,0f,0f), new Color(1f,1f,1f), duration / 4f);
        }
        OnAttackEventEmitter.Emit(new OnAttackEndEventData());
    }
}