using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public GameObject player;
	public int lives = 4;

	public Vector3 textPos; //0,-12,20
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		this.transform.position = player.transform.position+textPos;
	}

	// Update is called once per frame
	void Update () {
		
			GetComponent<TextMesh> ().text = "Lives: " + lives;
	}
}
