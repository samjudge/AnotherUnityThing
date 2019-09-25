using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StatCollection : MonoBehaviour {

    private List<StatModifier> Stats;
    
    void Awake() {
        this.Stats = new List<StatModifier>();
        StatModifier[] Stats = GetComponentsInChildren<StatModifier>();
        for(int x = 0; x < Stats.Length; x++){
            this.Stats.Add(Stats[x]);
        }
    }

    public float GetValue(string name) {
        float Value = 0f;
        foreach (StatModifier s in Stats) {
            if (s.Name == name) {
                Value += s.Value;
            }
        }
        return Value;
    }

    public bool HasStat(string name) {
        foreach (StatModifier s in Stats) {
            if (s.Name == name) {
                return true;
            }
        }
        return false;
    }

    public List<StatModifier> GetStatsWithSource(GameObject Source) {
        List<StatModifier> StatsWithSource = new List<StatModifier>();
        foreach(StatModifier s in Stats) {
            if(s.Source == Source) {
                StatsWithSource.Add(s);
            }
        }
        return StatsWithSource;
    }

    public void AddStat(StatModifier Stat) {
        Stat = Instantiate(Stat);
        Stat.transform.SetParent(transform);
        Stats.Add(Stat);
    }

    public void RemoveStat(StatModifier Stat) {
        Stats.Remove(Stat);
        Destroy(Stat.gameObject);
    }

    public List<StatModifier> GetAllStatModifiers() {
        return Stats;
    }

    public Dictionary<string, float> GetAllStats() {
        Dictionary<string, float> StatBonuses = new Dictionary<string, float>();
        foreach(StatModifier mod in GetAllStatModifiers()){
            if(StatBonuses.ContainsKey(mod.Name)) {
                StatBonuses[mod.Name] += mod.Value;
            } else {
                StatBonuses[mod.Name] = mod.Value;
            }
        }
        return StatBonuses;
    }

}