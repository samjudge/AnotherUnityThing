using System.Collections.Generic;
using UnityEngine;

public class OnPassiveCastEventData
{
    public GameObject Caster;

    public OnPassiveCastEventData(GameObject Caster) {
        this.Caster = Caster;
    }
}