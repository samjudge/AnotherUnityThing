using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private OnCastEventHandler OnCastHandler;
    [SerializeField]
    private OnCastEventEmitter CastEventEmitter;

    public OnCastEventEmitter GetEmitter(){
        return CastEventEmitter;
    }
}