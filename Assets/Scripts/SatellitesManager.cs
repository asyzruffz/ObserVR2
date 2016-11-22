using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class SatellitesManager : MonoBehaviour
{
    public GameObject source;
    public int amount = 10;
    public float radius = 20;

    void Start() {
		SphereCollider sphere = GetComponent<SphereCollider>();
		sphere.radius = radius;

        for (int i = 0; i < amount; ++i) {
			Vector3 direction = Random.onUnitSphere;

			GameObject satella = (GameObject)Instantiate(source, direction * radius, Quaternion.identity);
            satella.name = "Satellite";
            satella.transform.parent = gameObject.transform;
        }
    }
}