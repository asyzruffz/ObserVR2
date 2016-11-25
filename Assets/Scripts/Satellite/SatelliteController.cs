using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

	[Header("Movement")]
	public float speed = 10.0f;

	[Header("Laser")]
    public float laserDamage = 15f;
    public Laser chargingLaser;

	void Update() {
        SetLaserEnabled(GetComponent<Selectable>().connected);
    }

    public void SetLaserEnabled(bool enabled) {
        if (chargingLaser) {
            chargingLaser.on = enabled;
        }
	}

	public void FacingTowards(Transform target) {
		Vector3 fowardFace = (target.transform.position - transform.position).normalized;
		if(fowardFace != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation(fowardFace, transform.up) * Quaternion.Euler(Vector3.right * 90);
		}
	}
}
