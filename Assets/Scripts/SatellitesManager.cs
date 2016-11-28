using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class SatellitesManager : MonoBehaviour
{
    public GameObject source;
    public int amount = 10;
	public float radius = 20;
	[Range(0,180)]
	public float angleRange = 180f;

    void Start() {
		SphereCollider sphere = GetComponent<SphereCollider>();
		sphere.radius = radius;

		// Convert angle to normalized [0,90] degrees
		float verticalLimit = Mathf.Sin(angleRange / 2 * Mathf.Deg2Rad);

        for (int i = 0; i < amount; ++i) {
			Vector3 direction;
			do { // Reroll the dice if exceeding limit
				direction = Random.onUnitSphere;
			} while(Mathf.Abs(direction.y) > verticalLimit);

			GameObject satella = (GameObject)Instantiate(source, direction * radius, Quaternion.identity);
            satella.name = "Satellite";
            satella.transform.parent = gameObject.transform;
			satella.GetComponent<FauxGravityBody>().attractor = GetComponent<FauxGravityAttractor>();
			satella.GetComponent<SatelliteController> ().amplitude = radius * verticalLimit;
        }
    }
}