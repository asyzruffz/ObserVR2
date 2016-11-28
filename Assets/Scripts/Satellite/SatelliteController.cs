using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

	public float speed = 10.0f;
	[ShowOnly]
	public float amplitude = 50;

	private Vector2 direction;
	private Vector3 centreRotation = Vector3.zero;

	void Start() {
		direction = new Vector2(Random.Range (0, 2) * 2 - 1, Random.Range (0, 2) * 2 - 1);
		if (GetComponent<FauxGravityBody> () != null) {
			centreRotation = GetComponent<FauxGravityBody> ().attractor.transform.position;
		}
	}

	void FixedUpdate() {
		Vector3 relPos = transform.position - centreRotation;
		if (relPos.y > amplitude) {
			direction.y = -1;
		} else if (relPos.y < -amplitude) {
			direction.y = 1;
		}

		transform.Translate (DirectionFromPerspective (direction) * speed * Time.fixedDeltaTime);
    }

	private Vector3 DirectionFromPerspective(Vector2 dir) {
		// Convert (-1 / 1) direction to Vector3 direction relative to perspective
		Vector3 centreGravityDir = (centreRotation - transform.position).normalized;
		Vector3 dirRight = Vector3.Cross(centreGravityDir, Vector3.up).normalized;
		Vector3 dirUp = Vector3.Cross(dirRight, centreGravityDir).normalized;

		Vector3 totalDir = ((dirRight * dir.x) + (dirUp * dir.y)).normalized;
		return totalDir;
	}

	// Called by LaserManager
	public void FacingTowards(Transform target) {
		Vector3 fowardFace = (target.transform.position - transform.position).normalized;
		if(fowardFace != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation(fowardFace, Vector3.up) * Quaternion.Euler(Vector3.right * 90);
		}
	}
}
