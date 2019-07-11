using UnityEngine;

public class OnMouseMoveEventData {

    public Vector2 LastMousePosition;
    public Vector2 NewMousePosition;

    public OnMouseMoveEventData(
        Vector2 LastMousePosition,
        Vector2 NewMousePosition
    ){
        this.LastMousePosition = LastMousePosition;
        this.NewMousePosition = NewMousePosition;
    }
}