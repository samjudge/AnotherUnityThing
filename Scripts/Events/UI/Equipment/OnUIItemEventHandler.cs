using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnUIItemEventHandler : MonoBehaviour {
    [SerializeField]
    public OnUIItemDescribeEvent OnUIItemDescribeEvent;
    [SerializeField]
    public OnUIItemEquipEvent OnUIItemEquipEvent;
    [SerializeField]
    public OnUIItemUnequipEvent OnUIItemUnequipEvent;
    [SerializeField]
    public OnUIItemHoverEquipmentSlotEvent OnUIItemHoverEquipmentSlotEvent;
    [SerializeField]
    public OnUIItemEquipmentCompareEvent OnUIItemEquipmentCompareEvent;
    [SerializeField]
    public OnUIItemAttemptEquipEvent OnUIItemAttemptEquipEvent;
}
