using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingPotionItem : MonoBehaviour
{
    public OnItemEventEmitter OnItemEventEmitter;
    public Item Item;
    public GameObject DescriptionPrefab;

    public void Use(OnItemUseEventData e){
        Heal(e.User);
        RemoveFromInventoryOf(e.User);
    }

    public void UseInfinate(OnItemUseEventData e){
        Heal(e.User);
    }

    private void Heal(GameObject user){
        Health h = user.GetComponentInChildren<Health>();
        if(h != null){
            h.TakeDamage(-25f);
        }
    }

    private void RemoveFromInventoryOf(GameObject user){
        Debug.Log("Using HP pot?");
        ItemCollection c = user.GetComponentInChildren<ItemCollection>();
        if(c != null){
            Debug.Log("Using HP pot!");
            Destroy(gameObject);
            c.RemoveItem(Item);
        }
    }

    public void Collect(OnItemCollectEventData e){
        Debug.Log("Picked up HP pot!");
    }

    public void OnDescribeItem(OnUIItemDescribeEventData e){
        GameObject g = Instantiate(DescriptionPrefab);
        Text t = g.GetComponentInChildren<Text>();
        t.supportRichText = true;
        Health h = e.User.GetComponentInChildren<Health>();
        t.text = "A Potion Of Healing\n" +
            "HP " + h.CurrentValue + " -> <color=green>" + (h.CurrentValue + 25) + "</color>";
        g.GetComponent<RectTransform>().SetParent(e.DescriptionParent, false);
    }
}
