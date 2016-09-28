using UnityEngine;
using System.Collections;

public class SphericalController : MonoBehaviour {

    public Vector3 startPos;

    private SphericalMovement movement;

    // Use this for initialization
    void Start () {
        movement = GetComponent<SphericalMovement>();
        movement.SetRotation(startPos);
    }
	
	// Update is called once per frame
	void Update () {
        // Rotate with left/right arrows
        if (Input.GetKey(KeyCode.LeftArrow)) movement.Rotate(-360.0f);
        if (Input.GetKey(KeyCode.RightArrow)) movement.Rotate(360.0f);
        // Translate forward/backward with up/down arrows
        if (Input.GetKey(KeyCode.UpArrow)) movement.Translate(0, 180.0f);
        if (Input.GetKey(KeyCode.DownArrow)) movement.Translate(0, -180.0f);
        // Translate left/right with A/D. Bad keys but quick test.
        if (Input.GetKey(KeyCode.A)) movement.Translate(180.0f, 0);
        if (Input.GetKey(KeyCode.D)) movement.Translate(-180.0f, 0);

    }
}
