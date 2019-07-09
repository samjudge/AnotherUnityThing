using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Health Health;
    [SerializeField]
    private UIFillBar Bar;
    [SerializeField]
    private UIImageColorShifter BaseBarColorShifter;
    [SerializeField]
    private UIImageColorShifter BarColorShifter;
    [SerializeField]
    private float DisplayForXSecondsOnUpdate;

    void Start() {

    }

    public void UpdateBar(){
        Bar.SetValue(
            Health.CurrentValue /
            Health.MaxValue
        );
        Debug.Log("zzz");
        BarColorShifter.ShiftToColor(new Color(0,1,0,0), new Color(0,1,0,1));
        BaseBarColorShifter.ShiftToColor(new Color(1,0,0,0), new Color(1,0,0,1));
        StartCoroutine(ShiftBackAfter(DisplayForXSecondsOnUpdate));
    }

    private IEnumerator ShiftBackAfter(float s){
        yield return new WaitForSeconds(s);
        BarColorShifter.ShiftToColor(new Color(0,1,0,1), new Color(0,1,0,0));
        BaseBarColorShifter.ShiftToColor(new Color(1,0,0,1), new Color(1,0,0,0));
    }

}