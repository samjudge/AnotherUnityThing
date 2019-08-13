using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemOnCollision : MonoBehaviour
{
    [SerializeField]
    Item Item;

    public void OnCollisionEnter(Collision C){
        ItemCollection ItemCollection =
            C.gameObject.GetComponentInChildren<ItemCollection>();
        if(ItemCollection != null) {
            Item Item = Instantiate(this.Item);
            ItemCollection.AddItem(Item);
            Destroy(this.gameObject);
        }
    }
}
