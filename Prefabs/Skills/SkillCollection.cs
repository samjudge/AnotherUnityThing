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
            AddSkill(Skills[x]);
        }
    }

    public void AddSkill(Skill s){
        //so that it is using a local copy instead of a prefab..
        //this is required in order for the skill to maintain
        //some information about it's own state locally and non-statically
        s = Instantiate(s);
        s.transform.SetParent(transform);
        Skills.Add(s);
    }

    public List<Skill> GetSkills(){
        return this.Skills;
    }
}