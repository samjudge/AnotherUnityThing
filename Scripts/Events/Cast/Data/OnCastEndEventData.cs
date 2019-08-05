using System.Collections.Generic;
using UnityEngine;

public class OnCastEndEventData
{
    public GameObject Caster;

    public OnCastEndEventData(GameObject Caster) {
        this.Caster = Caster;
    }
}