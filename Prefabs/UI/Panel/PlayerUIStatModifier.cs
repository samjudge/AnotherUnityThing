using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIStatModifier : MonoBehaviour {
    [SerializeField]
    public StatCollection BasedOnStats;
    [SerializeField]
    public String Description;
    [SerializeField]
    public Sprite Icon;
}