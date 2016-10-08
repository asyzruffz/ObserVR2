using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

    public float laserDamage = 15f;
    public float speed = 1.0f;
    public float rotateSpeed = 360.0f;
    public Laser chargingLaser;

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
        if (chargingLaser)
        {
            chargingLaser.on = enabled;
        }
    }
}
