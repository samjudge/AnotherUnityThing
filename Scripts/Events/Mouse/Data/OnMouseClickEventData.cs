using UnityEngine;

public class OnMouseClickEventData
{
    public KeyCode ClickedButton;
    public Vector2 At;

    public OnMouseClickEventData(
        KeyCode ClickedButton,
        Vector2 At
    ){
        this.ClickedButton = ClickedButton;
        this.At = At;
    }
}