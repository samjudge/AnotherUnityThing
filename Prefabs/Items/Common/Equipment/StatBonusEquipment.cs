using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBonusEquipment : MonoBehaviour {

    [SerializeField]
    public List<StatModifier> StatBonuses;

    public void Equip(OnItemEquipEventData e) {
        StatCollection stats = e.Equipper
            .GetComponentInChildren<StatCollection>();
        foreach(StatModifier s in StatBonuses) {
            stats.AddStat(s);
        }
    }
    
    public void Unequip(OnItemUnequipEventData e) {
        StatCollection stats = e.Equipper.GetComponentInChildren<StatCollection>();
        foreach(StatModifier s in stats.GetStatsWithSource(e.Item.gameObject)) {
            stats.RemoveStat(s);
        }
    }
}