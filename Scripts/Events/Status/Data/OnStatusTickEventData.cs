using UnityEngine;

public class OnStatusTickEventData
{
    public GameObject Target;
    public GameObject Source;
    public float Duration;

    public OnStatusTickEventData(
        GameObject target,
        GameObject source,
        float duration
    ){
        Target = target;
        Source = source;
        Duration = duration;
    }
}