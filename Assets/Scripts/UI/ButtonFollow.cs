using UnityEngine;
using System.Collections;

public class ButtonFollow : MonoBehaviour {

    public BoxCollider boundingBox;

    private Bounds selfBound;
    private Bounds boxBound;

    void Start () {
        selfBound = GetComponent<SphereCollider> ().bounds;
    }
	
	void FixedUpdate () {
        boxBound = boundingBox.bounds;
        Debug.Log("Bounding Box " + boxBound.center.ToString());

        float shiftX, shiftY, shiftZ;
        shiftX = shiftY = shiftZ = 0;

        if (selfBound.max.x > boxBound.max.x) {
            shiftX = boxBound.max.x - selfBound.max.x;
        } else if (selfBound.min.x < boxBound.min.x) {
            shiftX = boxBound.min.x - selfBound.min.x;
        }
        if (selfBound.max.y > boxBound.max.y) {
            shiftY = boxBound.max.y - selfBound.max.y;
        } else if (selfBound.min.y < boxBound.min.y) {
            shiftY = boxBound.min.y - selfBound.min.y;
        }
        if (selfBound.max.z > boxBound.max.z) {
            shiftZ = boxBound.max.z - selfBound.max.z;
        } else if (selfBound.min.z < boxBound.min.z) {
            shiftZ = boxBound.min.z - selfBound.min.z;
        }

        //Debug.Log ("Shifting (" + shiftX + "," + shiftY + "," + shiftZ + ")");
        transform.Translate (new Vector3(shiftX, shiftY, shiftZ) * Time.fixedDeltaTime);
    }
}
