using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour {

    public FauxGravityAttractor attractor;
    public bool alwaysFacing;
    public Vector2 facingDirection;

    private Transform myTransform;

	void Start () {
        if(attractor == null) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            attractor = player.GetComponent<FauxGravityAttractor>();
        }

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;

        if(alwaysFacing) {
            facingDirection = facingDirection.normalized;
        }
    }
	
	void Update () {
        if (alwaysFacing) {
            attractor.Attract(myTransform, facingDirection);
        } else {
            attractor.Attract(myTransform);
        }
	}
}
