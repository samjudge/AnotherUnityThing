using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRunningHelper : MonoBehaviour
{
    public bool IsRunning = false;
    public AnimationRunningHelperEvent OnStartDelegate;
    public AnimationRunningHelperEvent OnEndDelegate;
    
    public void SetIsRunning(){
        IsRunning = true;
        OnStartDelegate?.Invoke();
        OnStartDelegate = null;
    }

    public void SetIsNotRunning(){
        IsRunning = false;
        OnEndDelegate?.Invoke();
        OnEndDelegate = null;
    }

    public void SetOnStartDelegate(AnimationRunningHelperEvent e){
        OnStartDelegate = e;
    }

    public void SetOnEndDelegate(AnimationRunningHelperEvent e){
        OnEndDelegate = e;
    }

    public delegate void AnimationRunningHelperEvent();

}
