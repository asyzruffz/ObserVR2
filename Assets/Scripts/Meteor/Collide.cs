using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {
	public CapsuleCollider hud;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		this.hud = player.GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider abc)
	{
		
		if(abc.Equals(hud))
		{
			SpawnMeteor.meteorCounter--;
			Destroy(this.gameObject);
		}

	}
}
