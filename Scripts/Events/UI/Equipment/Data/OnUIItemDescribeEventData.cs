using UnityEngine;

public class OnUIItemDescribeEventData
{
    public GameObject User;
    public Transform DescriptionParent;

    public OnUIItemDescribeEventData(GameObject user, Transform descriptionParent)
    {
        User = user;
        DescriptionParent = descriptionParent;
    }
}