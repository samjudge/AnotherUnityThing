using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnItemEventHandler : MonoBehaviour {
    [SerializeField]
    public OnItemUseEvent OnItemUseEvent;
    [SerializeField]
    public OnItemCollectEvent OnItemCollectEvent;
    [SerializeField]
    public OnItemEquipEvent OnItemEquipEvent;
    [SerializeField]
    public OnItemUnequipEvent OnItemUnequipEvent;
    [SerializeField]
    public OnItemAttemptEquipEvent OnItemAttemptEquipEvent;
}
