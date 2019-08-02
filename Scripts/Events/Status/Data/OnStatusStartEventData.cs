using UnityEngine;

public class OnStatusStartEventData
{
    public GameObject Target;
    public GameObject Source;
    public float Duration;

    public OnStatusStartEventData(
        GameObject target,
        GameObject source,
        float duration
    ){
        Target = target;
        Source = source;
        Duration = duration;
    }
}