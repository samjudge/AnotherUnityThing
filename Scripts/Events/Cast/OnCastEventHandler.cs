using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnCastEventHandler : MonoBehaviour {
    [SerializeField]
    public OnCancelCastEvent OnCancelCast;
    [SerializeField]
    public OnPassiveCastEvent OnPassiveCast;
    [SerializeField]
    public OnCastEndEvent OnEndCast;
    [SerializeField]
    public OnCastHitTargetEvent OnCastHitTarget;
    [SerializeField]
    public OnPointTargetCastEvent OnPointTargetCast;
    [SerializeField]
    public OnLockedTargetCast OnLockedTargetCast;
}
