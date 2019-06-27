using System;
using UnityEngine;

public class AttackEventEmitter : MonoBehaviour
{
    [SerializeField]
    private OnAttackEventHandler AttackEventHandler;

    public void emit(AttackLaunchEventData e)
    {
        AttackEventHandler.OnAttackLaunch.Invoke(e);
    }

    public void emit(AttackConnectEventData e)
    {
        AttackEventHandler.OnAttackConnect.Invoke(e);
    }

    public void emit(AttackEndEventData e)
    {
        AttackEventHandler.OnAttackEnd.Invoke(e);
    }
}