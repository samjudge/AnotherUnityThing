using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SkillCollection : MonoBehaviour
{
    private List<Skill> Skills;

    void Awake(){
        this.Skills = new List<Skill>();
        Skill[] Skills = this.GetComponentsInChildren<Skill>();
        for(int x = 0; x < Skills.Length; x++){
            this.Skills.Add(Skills[x]);
        }
    }

    public void AddSkill(Skill s){
        s.transform.SetParent(transform);
        s.transform.localPosition = Vector3.zero;
        Skills.Add(s);
    }

    public List<Skill> GetSkills(){
        return Skills;
    }

    public void RemoveSkill(Skill s){
        Skills.Remove(s);
    }
}