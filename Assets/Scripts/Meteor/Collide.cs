using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {
	public Collider hud;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		hud = player.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider abc)
	{
		if(abc.Equals(hud))
		{
			SpawnMeteor.meteorCounter--;
			Destroy(gameObject);
		}
	}
}
