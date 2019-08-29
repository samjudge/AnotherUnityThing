using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusionPotionItem : MonoBehaviour
{
    public OnItemEventEmitter OnItemEventEmitter;
    public Item Item;
    public Status ConfusionStatus;

    public void Use(OnItemUseEventData e) {
        ApplyConfusionTo(e.User);
        RemoveFromInventoryOf(e.User);
    }

    public void UseInfinate(OnItemUseEventData e) {
        ApplyConfusionTo(e.User);
    }

    private void ApplyConfusionTo(GameObject user) {
        StatusCollection statuses = user.GetComponentInChildren<StatusCollection>();
        if(statuses != null) {
            Status confusion = Instantiate(ConfusionStatus);
            statuses.AddStatus(confusion);
            confusion.Emitter.Emit(new OnStatusStartEventData(user, gameObject, 5f));
        }
    }

    private void RemoveFromInventoryOf(GameObject user) {
        ItemCollection c = user.GetComponentInChildren<ItemCollection>();
        if(c != null){
            Destroy(gameObject);
            c.RemoveItem(Item);
        }
    }

    public void Collect(OnItemCollectEventData e) {
        Debug.Log("Picked up Confusion pot!");
    }
}
