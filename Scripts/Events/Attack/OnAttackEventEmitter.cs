using System;
using UnityEngine;

public class OnAttackEventEmitter : MonoBehaviour
{
    [SerializeField]
    private OnAttackEventHandler AttackEventHandler;

    public void Emit(OnAttackLaunchEventData e)
    {
        AttackEventHandler.OnAttackLaunch.Invoke(e);
    }

    public void Emit(OnAttackConnectEventData e)
    {
        AttackEventHandler.OnAttackConnect.Invoke(e);
    }

    public void Emit(OnAttackEndEventData e)
    {
        AttackEventHandler.OnAttackEnd.Invoke(e);

    }
}