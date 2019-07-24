using System.Collections.Generic;
using UnityEngine;

public class OnPointTargetCastEventData
{
    public Vector3 Target;
    public GameObject Caster;
    public StatCollection Stats;

    public OnPointTargetCastEventData(
        GameObject Caster,
        Vector3 Target,
        StatCollection Stats
    ) {
        this.Caster = Caster;
        this.Target = Target;
        this.Stats = Stats;
    }
}