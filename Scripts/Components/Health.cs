using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public float CurrentValue;
    [SerializeField]
    public float MaxValue;

    public void TakeDamage(float Amount){
        CurrentValue -= Amount;
    }

    public void CapHealthToMax(){
        if(CurrentValue >= MaxValue){
            CurrentValue = MaxValue;
        }
    }
}
