using UnityEngine;

public class OnDamageRecievedEventData
{
    public float Damage;
    public GameObject Source;

    public OnDamageRecievedEventData(GameObject source, float damage)
    {
        Source = source;
        Damage = damage;
    }
}