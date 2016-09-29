using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

    public float speed = 1.0f;
    public float rotateSpeed = 360.0f;

    private SphericalMovement movement;
    
	void Start () {
        movement = GetComponent<SphericalMovement>();
    }
	
	void Update () {
        movement.Translate(0, speed);

        SetLaserEnabled(GetComponent<Selectable>().connected);
    }

    public void SetLaserEnabled(bool enabled)
    {
        Laser laser = gameObject.GetComponentInChildren<Laser>();
        if (laser)
        {
            laser.on = enabled;
        }
    }
}
