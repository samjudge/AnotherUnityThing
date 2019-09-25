using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDescription : MonoBehaviour
{
    private List<EquipmentDescriptionStatChange> StatChanges;
    [SerializeField]
    private Transform StatChangesRoot;
    public Text TopDescription;
    public Text BottomDescription;

    void Awake() {
        StatChanges = new List<EquipmentDescriptionStatChange>();
    }

    public void ClearStatChanges() {
        foreach(EquipmentDescriptionStatChange e in StatChanges) {
            Destroy(e.gameObject);
        }
        StatChanges.Clear();
    }

    public void AddStatChange(EquipmentDescriptionStatChange stat) {
        stat.transform.SetParent(StatChangesRoot, false);
        StatChanges.Add(stat);
    }

}
