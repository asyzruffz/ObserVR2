using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public bool on = false;
	public bool beamToMax = false;
	[ConditionalHide("beamToMax", true)]
    public float maxDistance = 50f;
	public LayerMask passThrough;

    private LineRenderer line;

	void Start () {
        line = GetComponent<LineRenderer>();
        line.enabled = on;
	}
	
	void Update () {
	    if(on) {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }
	}

    IEnumerator FireLaser() {
        line.enabled = true;

        while(on) {
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-Time.time * 0.2f, 0);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, transform.position);
			if(Physics.Raycast(ray, out hit, maxDistance, ~passThrough)) {
                line.SetPosition(1, hit.point);
            } else {
                line.SetPosition(1, beamToMax ? ray.GetPoint(maxDistance) : ray.GetPoint(0));
            }

            yield return null;
        }

        line.enabled = false;
    }
}
