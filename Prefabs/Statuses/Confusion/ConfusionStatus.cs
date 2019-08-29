using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ConfusionStatus : MonoBehaviour
{
    private float cTimer;
    [SerializeField]
    private OnStatusEventEmitter Emitter;
    [SerializeField]
    private Status Status;
    private Vector3 LastAddedMovement = Vector3.zero;
    private float LastAddedMovementMagnitude = 0f;

    void Update(){
        cTimer += Time.deltaTime;
    }

    public void StartConfusion(OnStatusStartEventData e){
        LastAddedMovement = Vector3.zero;
        LastAddedMovementMagnitude = 0f;
        ColorShifter shifter = 
            e.Target.GetComponentInChildren<ColorShifter>();
        if(shifter != null){
            shifter.ShiftToColor(
                new Color(1f,1f,1f,1f),
                new Color(1f,1f,0f,1f),
                1f
            );
        }
        StartCoroutine(RetickAfter(0f, new OnStatusTickEventData(e.Target, e.Source, e.Duration)));
    }

    public void TickConfusion(OnStatusTickEventData e) {
        MovableBody movableBody =
            e.Target.GetComponentInChildren<MovableBody>();
        if(movableBody != null) {
            RemoveLastRandomMovement(movableBody);
            AddRandomMovement(movableBody);
        }
        if(cTimer < e.Duration) {
            StartCoroutine(RetickAfter(0.1f, e));
        } else {
            Emitter.Emit(
                new OnStatusEndEventData(e.Target)
            );
        }
    }

    public void EndConfusion(OnStatusEndEventData e) {
        MovableBody movableBody =
            e.Target.GetComponentInChildren<MovableBody>();
        if(movableBody != null) {
            RemoveLastRandomMovement(movableBody);
        }
        StatusCollection Collection =
            e.Target.GetComponentInChildren<StatusCollection>();
        if(Collection != null) {
            Collection.RemoveStatus(Status);
        }
        ColorShifter shifter = 
            e.Target.GetComponentInChildren<ColorShifter>();
        if(shifter != null){
            shifter.ShiftToColor(
                new Color(1f,1f,0f,1f),
                new Color(1f,1f,1f,1f),
                1f
            );
            StartCoroutine(DestroyAfter(1f));
        } else {
            Destroy(gameObject);
        }
    }

    private void AddRandomMovement(MovableBody movableBody){
        LastAddedMovementMagnitude = Dice.Roll(0.5f,2f);
        LastAddedMovement = new Vector3(
            Dice.Roll(-1f,1f),
            0f,
            Dice.Roll(-1f,1f)
        );
        movableBody.AddToDirection(
            LastAddedMovement,
            LastAddedMovementMagnitude
        );
    }

    private void RemoveLastRandomMovement(MovableBody movableBody){
        movableBody.RemoveFromDirection(
            LastAddedMovement,
            LastAddedMovementMagnitude
        );
    }

    public IEnumerator DestroyAfter(float s) {
        yield return new WaitForSeconds(s);
        Destroy(gameObject);
    }

    private IEnumerator RetickAfter(float s, OnStatusTickEventData withData) {
        yield return new WaitForSeconds(s);
        Emitter.Emit(withData);
    }
}
