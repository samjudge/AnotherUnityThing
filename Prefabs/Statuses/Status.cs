using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField]
    public OnStatusEventHandler Handler;
    [SerializeField]
    public OnStatusEventEmitter Emitter;
    [SerializeField]
    public Sprite UIStatusImage;

     public OnStatusEventEmitter GetEmitter(){
        return Emitter;
    }
}