using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A MonoBehavior for a debugging agent with super powers
 */
public class DebuggerAgent : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z + 3 * Time.deltaTime 
            );
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z - 3 * Time.deltaTime 
            );
        }
        if (Input.GetKey(KeyCode.PageUp))
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z
            ) + this.transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z
            ) - this.transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(
                new Vector3(
                    0,
                    45 * Time.deltaTime,
                    0
                ),
                Space.World
            );
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(
                new Vector3(
                    0,
                    -45 * Time.deltaTime,
                    0
                ),
                Space.World
            );
        }
	}
}
