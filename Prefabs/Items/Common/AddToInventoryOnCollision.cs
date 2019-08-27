using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventoryOnCollision : MonoBehaviour
{
    public Item ItemPrefab;

    public void OnCollisionEnter(Collision C){
        OnInventoryEventEmitter Emitter =
            C.gameObject.GetComponentInChildren<OnInventoryEventEmitter>();
        if(Emitter != null) {
            Item Item = Instantiate(ItemPrefab);
            Item.Emitter.Emit(new OnItemCollectEventData(
                C.gameObject
            ));
            Emitter.Emit(new OnInventoryAddEventData(
                Item
            ));
            Destroy(gameObject);
        }
    }
}
