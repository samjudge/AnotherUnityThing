using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour {

    [SerializeField]
    private float MaxSpeed;
    [SerializeField]
    private float Acceleration;
    [SerializeField]
    private Rigidbody Body;

    void FixedUpdate(){
        //limit the speed of the provisioned body
        if(Body.velocity.magnitude > MaxSpeed){
            Body.velocity = Body.velocity.normalized * MaxSpeed;
        }
    }

	public void MoveByKeyEvent(OnKeyPressedEventData e){
        Vector3 force = new Vector3();
        switch(e.Key){
            case KeyCode.W : 
                force.z += Acceleration * Time.deltaTime;
                break;
            case KeyCode.S : 
                force.z -= Acceleration * Time.deltaTime;
                break;
            case KeyCode.A : 
                force.x -= Acceleration * Time.deltaTime;
                break;
            case KeyCode.D : 
                force.x += Acceleration * Time.deltaTime;
                break;
        }
        Body.AddForce(force);
    }
}
