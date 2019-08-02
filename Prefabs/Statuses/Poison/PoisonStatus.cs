using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PoisonStatus : MonoBehaviour
{
    private float cTimer;
    [SerializeField]
    private OnStatusEventEmitter Emitter;
    [SerializeField]
    private Status Status;

    void Update(){
        cTimer += Time.deltaTime;
    }

    public void StartPosion(OnStatusStartEventData e){
        ColorShifter shifter = 
            e.Target.GetComponentInChildren<ColorShifter>();
        if(shifter != null){
            shifter.ShiftToColor(
                new Color(1f,1f,1f,1f),
                new Color(0f,1f,0f,1f),
                1f
            );
        }
        StartCoroutine(RetickAfter(0f, new OnStatusTickEventData(e.Target, e.Source, e.Duration)));
    }

    public void TickPosion(OnStatusTickEventData e) {
        OnDamageEventEmitter emitter =
            e.Target.GetComponentInChildren<OnDamageEventEmitter>();
        if(emitter != null){
            emitter.Emit(new OnDamageRecievedEventData(e.Source, 5f));
        }
        if(cTimer < e.Duration){
            StartCoroutine(RetickAfter(0.5f, e));
        } else {
            Emitter.Emit(
                new OnStatusEndEventData(e.Target)
            );
        }
    }

    public void EndPosion(OnStatusEndEventData e){
        StatusCollection Collection =
            e.Target.GetComponentInChildren<StatusCollection>();
        if(Collection != null) {
            Collection.RemoveStatus(Status);
        }
        ColorShifter shifter = 
            e.Target.GetComponentInChildren<ColorShifter>();
        if(shifter != null){
            shifter.ShiftToColor(
                new Color(0f,1f,0f,1f),
                new Color(1f,1f,1f,1f),
                1f
            );
            StartCoroutine(DestroyAfter(1f));
        } else {
            Destroy(gameObject);
        }
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
