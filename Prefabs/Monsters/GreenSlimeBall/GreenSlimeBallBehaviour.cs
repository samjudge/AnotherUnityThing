using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GreenSlimeBallBehaviour : MonoBehaviour
{
    [SerializeField]
    private Health Health;
    [SerializeField]
    private OnDamageEventEmitter Emitter;
    [SerializeField]
    private ScrollingFadingTextBehaviourFactory DamageTextFactory;

    public void TakeDamage(OnDamageRecievedEventData DamageData)
    {
        Debug.Log("Oof :(");
        DamageTextFactory.Make("-" + DamageData.Damage.ToString());
        Health.TakeDamage(DamageData.Damage);
        if(Health.CurrentValue < 0) {
            Debug.Log("Wah!");
            Destroy(this.gameObject);
        }
    }
}
