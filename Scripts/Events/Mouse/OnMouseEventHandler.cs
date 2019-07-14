using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class OnMouseEventHandler : MonoBehaviour
{

    private Vector2 LastMouseInputPosition;
    [SerializeField]
    private Camera Face;
    [SerializeField]
    public OnMouseMoveEvent OnMouseMove;
    [SerializeField]
    public OnMouseClickEvent OnMouseClick;

    void Start() {
        //initalize mouse position
        LastMouseInputPosition = Input.mousePosition;
        if(Face == null) {
            Debug.LogWarning("MouseEventListener has no set Face, defaulting to `Camera.main`");
            Face = Camera.main;
        }
    }

    void Update() {
        if(!Input.mousePosition.Equals(LastMouseInputPosition)) {
            OnMouseMove.Invoke(
                new OnMouseMoveEventData(
                    LastMouseInputPosition,
                    Input.mousePosition
                )
            );
            LastMouseInputPosition = Input.mousePosition;
        }
        if(Input.GetKey(KeyCode.Mouse0)){
            OnMouseClick.Invoke(
                new OnMouseClickEventData(
                    KeyCode.Mouse0,
                    LastMouseInputPosition
                )
            );
        }
        if(Input.GetKey(KeyCode.Mouse1)){ //?? any better way?
            OnMouseClick.Invoke(
                new OnMouseClickEventData(
                    KeyCode.Mouse1,
                    LastMouseInputPosition
                )
            );
        }
    }
}
