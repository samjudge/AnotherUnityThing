using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class UIRenderableEquipment : MonoBehaviour
{
    [SerializeField]
    private EquipmentDescription DescriptionPrefab;
    [SerializeField]
    private EquipmentDescriptionStatChange StatLinePrefab;
    [SerializeField]
    private List<PlayerUIStatModifier> StatBonuses;
    [SerializeField]
    private Sprite EquipImage;
    [SerializeField]
    private String TopDescription;
    [SerializeField]
    private String BottomDescription;
    [SerializeField]
    private EquipableToSlotEquipment EquippableTo;

    public void Describe(OnUIItemDescribeEventData e){
        EquipmentDescription n = Instantiate(DescriptionPrefab);
        n.GetComponent<RectTransform>().SetParent(e.DescriptionParent, false);
        n.TopDescription.text = TopDescription;
        n.BottomDescription.text = BottomDescription;
        foreach(PlayerUIStatModifier stat in StatBonuses) {
            EquipmentDescriptionStatChange s = Instantiate(StatLinePrefab);
            s.Image.sprite = stat.Icon;
            s.Text.text = stat.Description;
            n.AddStatChange(s);
        }
    }

    public void UICompareTo(OnUIItemEquipmentCompareEventData e){
        e.StatChangesCollection.ClearAll();
        StatCollection playerStats = e.Player.GetComponentInChildren<StatCollection>();
        List<PlayerUIStatModifier> playerUIStats =
            new List<PlayerUIStatModifier>(playerStats.GetComponentsInChildren<PlayerUIStatModifier>());
        Dictionary<string, float> originalStatValues = new Dictionary<string, float>();
        Dictionary<string, float> bonusStatValues = new Dictionary<string, float>();
        Dictionary<string, PlayerUIStatModifier> renderables = new Dictionary<string, PlayerUIStatModifier>();
        foreach(PlayerUIStatModifier UIStat in playerUIStats) {
            foreach(KeyValuePair<string, float> stat in UIStat.BasedOnStats.GetAllStats()) {
                if(!originalStatValues.ContainsKey(stat.Key)) {
                    originalStatValues[stat.Key] = stat.Value;
                } else {
                    originalStatValues[stat.Key] += stat.Value;
                }
                if(!renderables.ContainsKey(stat.Key)) {
                    renderables[stat.Key] = UIStat;
                }
            }
        }
        foreach(PlayerUIStatModifier UIStat in StatBonuses) {
            foreach(KeyValuePair<string, float> stat in UIStat.BasedOnStats.GetAllStats()) {
                if(!bonusStatValues.ContainsKey(stat.Key)) {
                    bonusStatValues[stat.Key] = stat.Value;
                } else {
                    bonusStatValues[stat.Key] += stat.Value;
                }
                if(!renderables.ContainsKey(stat.Key)) {
                    renderables[stat.Key] = UIStat;
                }
            }
        }
        EquipmentCollection playerEquipment = e.Player.GetComponentInChildren<EquipmentCollection>();
        Item thisItem = GetComponent<Item>();
        //remove bonus values based on currently equipped item
        if(playerEquipment.IsItemInSlot(e.ForSlot)) {
            Item i = playerEquipment.GetItemInSlot(e.ForSlot);
            PlayerUIStatModifier[] UIStats = i.GetComponentsInChildren<PlayerUIStatModifier>();
            if(!playerEquipment.IsEquipped(thisItem)) {
                foreach(PlayerUIStatModifier UIStat in UIStats) {
                    foreach(KeyValuePair<string, float> stat in UIStat.BasedOnStats.GetAllStats()) {
                        if(!bonusStatValues.ContainsKey(stat.Key)) {
                            bonusStatValues[stat.Key] = -stat.Value;
                        } else {
                            bonusStatValues[stat.Key] -= stat.Value;
                        }
                        if(!renderables.ContainsKey(stat.Key)) {
                            renderables[stat.Key] = UIStat;
                        }
                    }
                }
            }
        }
        //remove bonus values based on if item is being re-equiped to another slot
        if(playerEquipment.IsEquipped(thisItem)) {
            PlayerUIStatModifier[] UIStats =
                thisItem.GetComponentsInChildren<PlayerUIStatModifier>();
            foreach(PlayerUIStatModifier UIStat in UIStats) {
                foreach(KeyValuePair<string, float> stat in UIStat.BasedOnStats.GetAllStats()) {
                    if(!bonusStatValues.ContainsKey(stat.Key)) {
                        bonusStatValues[stat.Key] = -stat.Value;
                    } else {
                        bonusStatValues[stat.Key] -= stat.Value;
                    }
                    if(!renderables.ContainsKey(stat.Key)) {
                        renderables[stat.Key] = UIStat;
                    }
                }
            }
        }
        foreach(KeyValuePair<string, PlayerUIStatModifier> UIStat in renderables) {
            if(originalStatValues.ContainsKey(UIStat.Key) &&
               bonusStatValues.ContainsKey(UIStat.Key) &&
               EquippableTo.ContainsSlot(e.ForSlot)
            ){
                e.StatChangesCollection.AddStatChange(
                    originalStatValues[UIStat.Key],
                    bonusStatValues[UIStat.Key],
                    UIStat.Value.Icon
                );
            } else if(originalStatValues.ContainsKey(UIStat.Key) && EquippableTo.ContainsSlot(e.ForSlot)) {
                e.StatChangesCollection.AddStatChange(
                    originalStatValues[UIStat.Key],
                    0,
                    UIStat.Value.Icon
                );
            } else if(bonusStatValues.ContainsKey(UIStat.Key) && EquippableTo.ContainsSlot(e.ForSlot)) {
                e.StatChangesCollection.AddStatChange(
                    0,
                    bonusStatValues[UIStat.Key],
                    UIStat.Value.Icon
                );
            }
        }
    }

    public void UIEquip(OnUIItemEquipEventData e) {
        Debug.Log(EquipImage);
        e.EquipmentSlotParent.ItemImage.sprite = EquipImage;
    }

    
    public void SlotHover(OnUIItemHoverEquipmentSlotEventData e){
        if(EquippableTo.ContainsSlot(e.Slot)) {
            e.SelectorObject.GetComponent<Image>().color = 
                new Color(1,1,1,1);
        } else {
            e.SelectorObject.GetComponent<Image>().color = 
                new Color(1,0,0,1);
        }
    }
}
