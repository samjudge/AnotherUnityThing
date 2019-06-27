using UnityEngine;

public class AttackConnectEventData
{
    public GameObject With;
    public int Damage;

    public AttackConnectEventData(GameObject With, int Damage){
        this.With = With;
        this.Damage = Damage;
    }
}