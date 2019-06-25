using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnAttackEventHandler : MonoBehaviour {
    [SerializeField]
    public AttackLaunchEvent OnAttackLaunch;
    [SerializeField]
    public AttackConnectEvent OnAttackConnect;
    [SerializeField]
    public AttackEndEvent OnAttackEnd;
}
