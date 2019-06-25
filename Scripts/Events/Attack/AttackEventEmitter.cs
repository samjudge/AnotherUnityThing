using System;
using UnityEngine;

public class AttackEventEmitter : MonoBehaviour
{
    [SerializeField]
    private OnAttackEventHandler AttackEventHandler;

    public void emit(AttackLaunchEventData AttackLaunchEventData)
    {
        AttackEventHandler.OnAttackLaunch.Invoke(AttackLaunchEventData);
    }

    public void emit(AttackConnectEventData AttackConnectEventData)
    {
        AttackEventHandler.OnAttackConnect.Invoke(AttackConnectEventData);
    }

    public void emit(AttackEndEventData AttackEndEventData)
    {
        AttackEventHandler.OnAttackEnd.Invoke(AttackEndEventData);
    }
}