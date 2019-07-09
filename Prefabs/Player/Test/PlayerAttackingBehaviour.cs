using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingBehaviour : MonoBehaviour {

    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private BasicProjectileBehaviourFactory Factory;
    
    public void AttackByKeyEvent(OnKeyDownEventData e){
        switch(e.Key){
           case KeyCode.Mouse0 :
                LaunchAttack();
                break;
        }
    }

    private void LaunchAttack(){ 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(
            new Vector3(0f, 1f, 0f),
            transform.position
        );
        float distance = 0f;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        Vector3 direction = point - transform.position;
        Factory.Make(
            direction
        );
    }
}
