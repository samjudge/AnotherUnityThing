using UnityEngine;

public class OnAttackConnectEventData
{
    public GameObject With;
    public int Damage;

    public OnAttackConnectEventData(GameObject With, int Damage){
        this.With = With;
        this.Damage = Damage;
    }
}