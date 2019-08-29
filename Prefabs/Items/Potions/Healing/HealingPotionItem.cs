using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotionItem : MonoBehaviour
{
    public OnItemEventEmitter OnItemEventEmitter;
    public Item Item;

    public void Use(OnItemUseEventData e) {
        Heal(e.User);
        RemoveFromInventoryOf(e.User);
    }

    public void UseInfinate(OnItemUseEventData e) {
        Heal(e.User);
    }

    private void Heal(GameObject user){
        Health h = user.GetComponentInChildren<Health>();
        if(h != null){
            h.TakeDamage(-25f);
        }
    }

    private void RemoveFromInventoryOf(GameObject user){
        ItemCollection c = user.GetComponentInChildren<ItemCollection>();
        if(c != null){
            Destroy(gameObject);
            c.RemoveItem(Item);
        }
    }

    public void Collect(OnItemCollectEventData e) {
        Debug.Log("Picked up HP pot!");
    }
}
