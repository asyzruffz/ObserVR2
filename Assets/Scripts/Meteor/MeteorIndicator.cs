using UnityEngine;
using System.Collections;

public class MeteorIndicator : MonoBehaviour {

	public GameObject player;

	public Vector3 textPos;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		this.transform.position = player.transform.position+textPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (SpawnMeteor.meteorCounter > 0) {
			GetComponent<TextMesh> ().text = "Incoming Meteor Attack!!";
		} else {
			GetComponent<TextMesh> ().text = "You are safe for now.....";
		}
	}
}
