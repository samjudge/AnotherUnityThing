using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StatCollection
{
    private Dictionary<string, float> Stats;

    public StatCollection(params KeyValuePair<string,float>[] Stats){
        this.Stats = new Dictionary<string, float>();
        SetStats(Stats);
    }

    public float GetValue(string name, float defaultValue)
    {
        if(Stats.ContainsKey(name)){
            return Stats[name];
        }
        return defaultValue;
    }

    public void SetStats(params KeyValuePair<string,float>[] Stats){
        foreach(KeyValuePair<string,float> Stat in Stats){
            this.Stats[Stat.Key] = Stat.Value;
        }
    }
}