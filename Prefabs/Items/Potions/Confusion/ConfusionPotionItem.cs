using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfusionPotionItem : MonoBehaviour
{
    public OnItemEventEmitter OnItemEventEmitter;
    public Item Item;
    public Status ConfusionStatus;
    [SerializeField]
    private GameObject DescriptionPrefab;

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

    public void OnItemDescribeEent(OnUIItemDescribeEventData e) {
        GameObject g = Instantiate(DescriptionPrefab);
        Text t = g.GetComponentInChildren<Text>();
        t.supportRichText = true;
        Health h = e.User.GetComponentInChildren<Health>();
        t.text = "A Potion Of Confusion\n" +
            "Will <color=yellow>Confuse</color> the drinker";
        g.GetComponent<RectTransform>().SetParent(e.DescriptionParent, false);
    }

    public void Collect(OnItemCollectEventData e) {
        Debug.Log("Picked up Confusion pot!");
    }
}
