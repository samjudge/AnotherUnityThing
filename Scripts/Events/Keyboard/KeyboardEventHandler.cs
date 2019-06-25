using System;
using System.Collections.Generic;
using UnityEngine;

/**
 * Keybord event lifecycle manager
 */
public class KeyboardEventHandler : MonoBehaviour{

    [SerializeField]
    private KeyDownEvent OnKeyDown;
    [SerializeField]
    private KeyPressedEvent OnKeyPressed;
    [SerializeField]
    private KeyUpEvent OnKeyUp;

    private Dictionary<KeyCode, KeyPressedEventData> PressedKeyCodes;
    
    public void Awake(){ 
        this.PressedKeyCodes =
            new Dictionary<KeyCode, KeyPressedEventData>();
    }

    public void Update(){
        KeyCode[] keyCodes = (KeyCode[]) Enum.GetValues(typeof(KeyCode));
        foreach(KeyCode keyCode in keyCodes) {
            if(Input.GetKey(keyCode)){
                if(PressedKeyCodes.ContainsKey(keyCode)){
                    KeyPressedEventData e = PressedKeyCodes[keyCode];
                    e.duration += Time.deltaTime;
                    OnKeyPressed.Invoke(e);
                } else {
                    OnKeyDown.Invoke(new KeyDownEventData(keyCode));
                    PressedKeyCodes.Add(keyCode, new KeyPressedEventData(keyCode));
                }
            } else {
                if(PressedKeyCodes.ContainsKey(keyCode)){
                    PressedKeyCodes.Remove(keyCode);
                    OnKeyUp.Invoke(new KeyUpEventData(keyCode));
                }
            }
        }
    }
}
