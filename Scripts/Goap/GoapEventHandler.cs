using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GoapEventHandler : MonoBehaviour
{
    public List<GoapFunctionPair> Events;

    void Awake() {
        Events = new List<GoapFunctionPair>();
    }

    void Update(){
        // G is Nullable
        GoapActionFunction Action = GetGoapEventWithHighestHScore();
        if(Action != null){
            Action();
        }
    }

    private GoapActionFunction GetGoapEventWithHighestHScore(){
        //im lazy, using this as a Pair type since it exists
        KeyValuePair<uint, GoapFunctionPair> highest = new KeyValuePair<uint, GoapFunctionPair>(0, null);
        foreach(GoapFunctionPair e in Events){
            uint hScore = e.Heuristic();
            if(hScore > highest.Key) {
                highest = new KeyValuePair<uint, GoapFunctionPair>(hScore, e);
            }
        }
        return highest.Value.Action;
    }
}
