using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandAroundBehaviour : MonoBehaviour
{
    [SerializeField]
    private GoapEventHandler GoapSystem;
    [SerializeField]
    private MovableBody Movement;
    [SerializeField]
    private uint Priority;

    // Start is called before the first frame update
    void Start()
    {
        GoapSystem.Events.Add(
            new GoapFunctionPair(
                ShouldStandStill,
                StandStill
            )
        );
    }

    private uint ShouldStandStill(){
        return Priority;
    }

    private void StandStill(){
        Movement.SetDirection(Vector3.zero);
    }
}
