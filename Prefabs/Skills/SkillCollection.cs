using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SkillCollection : MonoBehaviour
{
    private Dictionary<String, Skill> Skills;

    void Awake(){
        this.Skills = new Dictionary<String, Skill>();
        Skill[] Skills = this.GetComponentsInChildren<Skill>();
        for(int x = 0; x < Skills.Length; x++) {
            this.Skills[Skills[x].Label] = Skills[x];
        }
    }

    public void AddSkill(Skill s){
        s.transform.SetParent(transform);
        s.transform.localPosition = Vector3.zero;
        Skills[s.Label] = s;
    }

    public List<Skill> GetSkills(){
        return new List<Skill>(Skills.Values);
    }

    public void RemoveSkill(Skill s){
        List<Skill> Skills = GetSkills();
        foreach(Skill sk in Skills){
            if(sk == s) {
                this.Skills.Remove(s.Label);
                return;
            }
        }
        throw new UnknownNamedSkillException(
            "Attempted to remove non-existant skill `" + s.Label + "`"
        );
    }

    public Skill GetNamedSkill(string SkillLabel){
        if(!Skills.ContainsKey(SkillLabel)){
            throw new UnknownNamedSkillException(
                "Attempted to retrieve non-existant skill `" + SkillLabel + "`"
            );
        }
        return Skills[SkillLabel];
    }
}