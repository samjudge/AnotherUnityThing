using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OnUIItemEventEmitter : MonoBehaviour {

    [SerializeField]
    private OnUIItemEventHandler Handler;

    public void Emit(OnUIItemDescribeEventData e){
        Handler.OnUIItemDescribeEvent.Invoke(e);
    }

    public void Emit(OnUIItemEquipEventData e){
        Handler.OnUIItemEquipEvent.Invoke(e);
    }

    public void Emit(OnUIItemUnequipEventData e){
        Handler.OnUIItemUnequipEvent.Invoke(e);
    }

    public void Emit(OnUIItemHoverEquipmentSlotEventData e) {
        Handler.OnUIItemHoverEquipmentSlotEvent.Invoke(e);
    }

    public void Emit(OnUIItemEquipmentCompareEventData e){
        Handler.OnUIItemEquipmentCompareEvent.Invoke(e);
    }

    public void Emit(OnUIItemAttemptEquipEventData e){
        Handler.OnUIItemAttemptEquipEvent.Invoke(e);
    }
}
