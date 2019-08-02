using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StatusCollection : MonoBehaviour
{
    private List<Status> Statuses;

    void Awake(){
        this.Statuses = new List<Status>();
        Status[] Statuses = GetComponentsInChildren<Status>();
        for(int x = 0; x < Statuses.Length; x++){
            this.Statuses.Add(Statuses[x]);
        }
    }

    public void AddStatus(Status s){
        s.transform.SetParent(transform);
        s.transform.localPosition = Vector3.zero;
        Statuses.Add(s);
    }

    public List<Status> GetStatuses(){
        return Statuses;
    }

    public void RemoveStatus(Status s){
        Statuses.Remove(s);
    }
}