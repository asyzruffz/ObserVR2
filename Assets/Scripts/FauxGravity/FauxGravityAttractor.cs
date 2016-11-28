using UnityEngine;
using System.Collections;

public class FauxGravityAttractor : MonoBehaviour {

    public float gravity = 10;

	public void Attract(Transform body, bool rotateUpwardGravity) {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * -gravity);

		if (rotateUpwardGravity) {
			Quaternion targetRotation = Quaternion.FromToRotation (bodyUp, gravityUp) * body.rotation;
			body.rotation = Quaternion.Slerp (body.rotation, targetRotation, 50 * Time.deltaTime);
		}
    }

    public void Attract(Transform body, Vector3 facing) {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        Vector3 bodyForward = body.forward;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * -gravity);

        Vector3 dirLeft = Vector3.Cross(gravityUp, facing).normalized;
        Vector3 dirForward = Vector3.Cross(dirLeft, gravityUp).normalized;
        dirForward.x *= -1;

        Quaternion upwardRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        Quaternion targetRotation = Quaternion.FromToRotation(bodyForward, dirForward) * upwardRotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
