using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Billboard
 * 
 * Utility class to billboard a sprite to face the camera
 */
public class Billboard : MonoBehaviour {
	/**
     * @var Camera face
     * the camera that the prefab should face
     */
    [SerializeField]
    private Camera Face;

    /**
     * @var Transform transfrom
     * the prefab to change the facing of
     */
    [SerializeField]
    private Transform Transform;

	void Update () {
        Vector3 cameraFacing = Face.transform.rotation.eulerAngles;
		Transform.rotation = Quaternion.Euler(
            cameraFacing.x,
            cameraFacing.y,
            cameraFacing.z
        );
	}

    public void SetFace(Camera Face) {
        this.Face = Face;
    }
}
