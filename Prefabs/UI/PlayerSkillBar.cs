using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillBar : MonoBehaviour
{
    [SerializeField]
    private SkillCollection Skills;
    [SerializeField]
    private Button[] SkillButtons;
    [SerializeField]
    private GameObject Caster;
    [SerializeField]
    private PlayerLockOnBehaviour PlayerLock;
    [SerializeField]
    private PlayerAttackingBehaviour PlayerAttack;

    void Start(){
        for(int n = 0; n < SkillButtons.Length; n++){
            if(n < Skills.GetSkills().Count){
                Skill s = Skills.GetSkills()[n];
                SkillButtons[n].image.sprite = s.UISkillImage;
                int cIndex = n;
                SkillButtons[n].onClick.AddListener(delegate(){
                   PlayerAttack.CastSpell(cIndex);
                });
            }
        }
    }

    void Update(){
    }

}
