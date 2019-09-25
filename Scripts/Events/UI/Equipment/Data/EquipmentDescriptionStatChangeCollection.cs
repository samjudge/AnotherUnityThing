using UnityEngine;
using UnityEngine.UI;

public class EquipmentDescriptionStatChangeCollection : MonoBehaviour
{
    [SerializeField]
    private EquipmentDescriptionStatChange StatChangePrefab;

    public void ClearAll(){
        foreach (Transform t in transform) {
            Destroy(t.gameObject);
        }
    }

    public void AddStatChange(float statFrom, float statChange, Sprite withIcon){
        EquipmentDescriptionStatChange statChangeUI = Instantiate(StatChangePrefab);
        statChangeUI.transform.SetParent(transform, false);
        statChangeUI.Image.sprite = withIcon;
        string colorTag = "";
        string colorCloseTag = "";
        if(statChange < 0) {
            colorTag = "<color=#f00f>";
            colorCloseTag = "</color>";
        } else if (statChange > 0) {
            colorTag = "<color=#0f0f>";
            colorCloseTag = "</color>";
        }
        statChangeUI.Text.text = colorTag + statFrom + " -> " + (statFrom + statChange) + colorCloseTag;
    }
}