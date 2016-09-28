using UnityEngine;
using System.Collections;

public class RotateCameraDrone : MonoBehaviour {

    public Transform character;
    public float rotateSpeed;
    public Vector3 rotateDirection;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Rigidbody body = gameObject.GetComponent<Rigidbody>();
        rotateDirection = Vector3.Cross(character.position - gameObject.transform.position, Vector3.up).normalized;
        gameObject.transform.position = gameObject.transform.position + rotateDirection * rotateSpeed;
        //body.AddForce(rotateDirection * rotateSpeed);
    }
}
