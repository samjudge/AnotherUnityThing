using UnityEngine;

public class OnAttackConnectEventData
{
    public GameObject With;
    public float Damage;

    public OnAttackConnectEventData(GameObject With, float Damage){
        this.With = With;
        this.Damage = Damage;
    }
}