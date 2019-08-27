using UnityEngine;

public class OnInventoryAddEventData
{
    public Item Item;

    public OnInventoryAddEventData(
        Item item
    )
    {
        Item = item;
    }
}