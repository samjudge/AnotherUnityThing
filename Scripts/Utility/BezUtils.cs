using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Utilies for vector manipulation
 */
public static class BezUtils {

    public static Vector3 Bez2(
        Vector3 p0,
        Vector3 p1,
        float t
    ) {
        return p1 + (p1 - p0) * t;
    }

    public static Vector3 Bez3(
        Vector3 p0,
        Vector3 p1,
        Vector3 p2,
        float t
    ) {
        //Debug.Log("t -> " + t);
        Vector3 q0 = 
            p0 + (p1 - p0) * t;
        //Debug.Log("q0 -> " + q0);
        Vector3 q1 = 
            p1 + (p2 - p1) * t;
        //Debug.Log("q1 -> " + q0);
        Vector3 q2 =
            q0 + (q1 - q0) * t;
        //Debug.Log("q2 -> " + q2);
        return q2;
    }
}
