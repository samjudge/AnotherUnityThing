using UnityEngine;

public class OnItemCollectEventData
{
    public GameObject CollectedBy;

    public OnItemCollectEventData(
        GameObject collectedBy
    )
    {
        CollectedBy = collectedBy;
    }
}