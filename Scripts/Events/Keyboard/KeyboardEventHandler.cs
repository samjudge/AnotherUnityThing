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

    private Dictionary<KeyCode, OnKeyPressedEventData> PressedKeyCodes;
    
    public void Awake(){ 
        this.PressedKeyCodes =
            new Dictionary<KeyCode, OnKeyPressedEventData>();
    }

    public void Update(){
        KeyCode[] keyCodes = (KeyCode[]) Enum.GetValues(typeof(KeyCode));
        foreach(KeyCode keyCode in keyCodes) {
            if(Input.GetKey(keyCode)){
                if(PressedKeyCodes.ContainsKey(keyCode)){
                    OnKeyPressedEventData e = PressedKeyCodes[keyCode];
                    e.duration += Time.deltaTime;
                    OnKeyPressed.Invoke(e);
                } else {
                    OnKeyDown.Invoke(new OnKeyDownEventData(keyCode));
                    PressedKeyCodes.Add(keyCode, new OnKeyPressedEventData(keyCode));
                }
            } else {
                if(PressedKeyCodes.ContainsKey(keyCode)){
                    PressedKeyCodes.Remove(keyCode);
                    OnKeyUp.Invoke(new OnKeyUpEventData(keyCode));
                }
            }
        }
    }
}
