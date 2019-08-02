using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private OnCastEventHandler OnCastHandler;
    [SerializeField]
    private OnCastEventEmitter CastEventEmitter;
    [SerializeField]
    public Sprite UISkillImage;

    public OnCastEventEmitter GetEmitter(){
        return CastEventEmitter;
    }

    public OnCastEventHandler GetHandler(){
        return OnCastHandler;
    }
}