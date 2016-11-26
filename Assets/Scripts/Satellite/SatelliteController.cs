using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

	public float speed = 10.0f;

	private int direction;
	private Vector3 centreRotation = Vector3.zero;

	void Start() {
		direction = Random.Range (0, 2) * 2 - 1;
		if (GetComponent<FauxGravityBody> () != null) {
			centreRotation = GetComponent<FauxGravityBody> ().attractor.transform.position;
		}
	}

	void FixedUpdate() {
		transform.Translate (DirectionFromPerspective (direction) * speed * Time.fixedDeltaTime);
    }

	private Vector3 DirectionFromPerspective(float dir) {
		// Convert (-1 / 1) direction to Vector3 direction relative to perspective
		Vector3 centreGravityDir = (centreRotation - transform.position).normalized;
		Vector3 dirRight = Vector3.Cross(centreGravityDir, Vector3.up).normalized;
		return dirRight * dir;
	}

	// Called by LaserManager
	public void FacingTowards(Transform target) {
		Vector3 fowardFace = (target.transform.position - transform.position).normalized;
		if(fowardFace != Vector3.zero) {
			//Quaternion targetRotation = Quaternion.LookRotation(fowardFace, transform.up) * Quaternion.Euler(Vector3.right * 90);
			transform.rotation = Quaternion.LookRotation(fowardFace, transform.up) * Quaternion.Euler(Vector3.right * 90);
			//transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, 50 * Time.deltaTime);
		}
	}
}
