using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MovableBody : MonoBehaviour
{
    [SerializeField]
    private Vector3 Direction;
    [SerializeField]
    private float MaxSpeed;
    [SerializeField]
    private float Acceleration;
    [SerializeField]
    private Rigidbody Body;
    
    void FixedUpdate(){
        //limit the speed of the provisioned body
        Body.AddForce(Direction.normalized * Acceleration);
        if(Body.velocity.magnitude > MaxSpeed){
            Body.velocity = Body.velocity.normalized * MaxSpeed;
        }
    }
    
    public float GetAcceleration() {
        return this.Acceleration;
    }

    public void SetAcceleration(float Acceleration) {
        this.Acceleration = Acceleration;
    }
    
    public float GetMaxSpeed(){
        return this.MaxSpeed;
    }

    public void SetMaxSpeed(float MaxSpeed) {
        this.MaxSpeed = MaxSpeed;
    }

    public Vector3 GetDirection(){
        return Direction;
    }

    public void SetDirection(Vector3 Direction) {
        Direction = Vector3.zero;
        AddToDirection(Direction, 1);
    }

    public void AddToDirection(Vector3 Direction, float WithMagnitude) {
        this.Direction += Direction.normalized * WithMagnitude;
    }

    public void RemoveFromDirection(Vector3 Direction, float WithMagnitude) {
        AddToDirection(Direction, -WithMagnitude);
    }
    
}
