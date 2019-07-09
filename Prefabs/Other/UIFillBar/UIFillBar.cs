using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFillBar : MonoBehaviour {

    private float Value;
    [SerializeField]
    private Image Bar;

    public void SetValue(float Value) {
        this.Value = Value;
        UpdateBar();
    }

    private void UpdateBar() {
        Bar.fillAmount = Value;
    }
}
