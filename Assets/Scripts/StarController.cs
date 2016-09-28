using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

    public float speed = 1.0f;
    public float rotateSpeed = 360.0f;

    private SphericalMovement movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<SphericalMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        movement.Translate(0, speed);
    }
}
