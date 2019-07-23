using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour {

    [SerializeField]
    private MovableBody Movement;

    private Vector3 ForceByKeyPress;
    private Vector3 LastSeenForceByKeyPress;

    void Update() {
        Movement.RemoveFromDirection(LastSeenForceByKeyPress.normalized, 1);
        LastSeenForceByKeyPress = ForceByKeyPress;
        Movement.AddToDirection(ForceByKeyPress.normalized, 1);
        ForceByKeyPress = Vector3.zero;
    }

	public void MoveByKeyEvent(OnKeyPressedEventData e){
        switch(e.Key){
            case KeyCode.W : 
                ForceByKeyPress.z += 1;
                break;
            case KeyCode.S : 
                ForceByKeyPress.z -= 1;
                break;
            case KeyCode.A : 
                ForceByKeyPress.x -= 1;
                break;
            case KeyCode.D : 
                ForceByKeyPress.x += 1;
                break;
        }
    }
}
