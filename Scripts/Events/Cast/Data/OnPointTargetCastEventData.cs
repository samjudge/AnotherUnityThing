using System.Collections.Generic;
using UnityEngine;

public class OnPointTargetCastEventData
{
    public Vector3 Target;
    public GameObject Caster;
    public Dictionary<string, float> Stats;

    public OnPointTargetCastEventData(
        GameObject Caster,
        Vector3 Target,
        Dictionary<string, float> Stats
    ) {
        this.Caster = Caster;
        this.Target = Target;
        this.Stats = Stats;
    }
}