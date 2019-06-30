using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public bool FollowX;
    public bool FollowY;
    public bool FollowZ;
    public GameObject Target;
    public float DistanceX;
    public float DistanceY;
    public float DistanceZ;

    // Update is called once per frame
    void Update () {
        if (FollowX) {
            this.transform.position = new Vector3(
                Target.transform.position.x - DistanceX,
                this.transform.position.y,
                this.transform.position.z
            );
        }
        if (FollowY) {
            this.transform.position = new Vector3(
                this.transform.position.x,
                Target.transform.position.y - DistanceY,
                this.transform.position.z
            );
        }
        if (FollowZ) {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                Target.transform.position.z - DistanceZ
            );
        }
	}
}
