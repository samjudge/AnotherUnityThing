using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotionItem : MonoBehaviour
{
    public OnItemEventEmitter OnItemEventEmitter;
    public Item Item;

    public void Use(OnItemUseEventData e) {
        Health h = e.User.GetComponentInChildren<Health>();
        if(h != null){
            h.TakeDamage(-25f);
        }
        ItemCollection c = e.User.GetComponentInChildren<ItemCollection>();
        if(c != null){
            Destroy(gameObject);
            c.RemoveItem(Item);
        }
    }
}
