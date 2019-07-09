using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackedBehaviour : MonoBehaviour {
    [SerializeField]
    public HealthBar HealthBar;
    [SerializeField]
    public Health Health;

    public void TakeDamage(OnDamageRecievedEventData e){
        Health.TakeDamage(e.Damage);
        HealthBar.UpdateBar();
    }

}
