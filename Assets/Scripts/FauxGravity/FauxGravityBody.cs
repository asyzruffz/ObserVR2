using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour {

    public FauxGravityAttractor attractor;

    private Transform myTransform;

	void Start () {
        if(attractor == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            attractor = player.GetComponent<FauxGravityAttractor>();
        }
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
    }
	
	void Update () {
        attractor.Attract(myTransform);
	}
}
