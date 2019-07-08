using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MovableBody : MonoBehaviour
{
    [SerializeField]
    public Vector3 Direction;
    [SerializeField]
    public float MaxSpeed;
    [SerializeField]
    public float Acceleration;
    [SerializeField]
    private Rigidbody Body;
    
    void FixedUpdate(){
        //limit the speed of the provisioned body
        Body.AddForce(Direction.normalized * Acceleration);
        if(Body.velocity.magnitude > MaxSpeed){
            Body.velocity = Body.velocity.normalized * MaxSpeed;
        }
    }
    
}
