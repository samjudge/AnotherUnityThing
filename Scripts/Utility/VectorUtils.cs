using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Utilies for vector manipulation
 */
public class VectorUtils {
    /**
     * Limits the component values of In to the component values of Max
     */
    public static Vector3 BoundVectorComponents(Vector3 In, Vector3 Max, Vector3 Min){
        Vector3 newVector = In;
        if(In.x > Max.x){
            newVector.x = Max.x;
        }
        if(In.x < Min.x){
            newVector.x = Min.x;
        }
        if(In.y > Max.y){
            newVector.y = Max.y;
        }
        if(In.y < Min.y){
            newVector.y = Min.y;
        }
        if(In.z > Max.z){
            newVector.z = Max.z;
        }
        if(In.z < Min.z){
            newVector.z = Min.z;
        }
        return newVector;
    }
}
