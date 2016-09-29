using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour {

    public FauxGravityAttractor attractor;
	GameObject player;

    private Transform myTransform;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		this.attractor = player.GetComponent<FauxGravityAttractor>();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
    }
	
	void Update () {
        attractor.Attract(myTransform);
	}
}
