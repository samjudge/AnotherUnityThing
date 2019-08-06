using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WanderAroundBehaviour : MonoBehaviour
{
    [SerializeField]
    private GoapEventHandler GoapSystem;
    [SerializeField]
    private MovableBody Movement;
    [SerializeField]
    private uint BasePriority = 1;
    [SerializeField]
    private float WanderAroundFor = 1f;
    private float cWanderAroundFor = 0f;
    [SerializeField]
    private float BonusPriorityPerSecond = 0f;
    private float BonusPriority = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GoapSystem.Events.Add(
            new GoapFunctionPair(
                ShouldWanderAround,
                WanderAround
            )
        );
    }

    private Vector3 WanderAroundDirection;

    private void WanderAround(){
        if(Movement.GetDirection() == Vector3.zero){
            Movement.SetDirection(
                new Vector3(
                    Dice.Roll(-1f, 1f),
                    0f,
                    Dice.Roll(-1f, 1f)
                ).normalized
            );
        }
        cWanderAroundFor += Time.deltaTime;
        if(cWanderAroundFor > WanderAroundFor){
            cWanderAroundFor = 0f;
            BonusPriority = 0f;
            Movement.SetDirection(Vector3.zero);
        }
    }

    private uint ShouldWanderAround(){
        BonusPriority += BonusPriorityPerSecond * Time.deltaTime;
        return BasePriority + (uint) BonusPriority;
    }
}
