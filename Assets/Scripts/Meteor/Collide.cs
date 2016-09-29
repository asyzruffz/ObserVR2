using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {
	public Collider hud;
	GameObject player;
	AudioSource[] aSource;
	AudioSource painSound;
	AudioSource deathSound;

	PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		hud = player.GetComponent<Collider>();

		this.hud = player.GetComponent<CapsuleCollider>();
		playerHealth = player.GetComponentInChildren<PlayerHealth> ();

		//to play different audio
		aSource = GetComponents<AudioSource> ();
		painSound = aSource [0]; //will give error but still working
		deathSound = aSource [1];

	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider abc)
	{

		if(abc.Equals(hud))
		{
			if (playerHealth.lives == 1) {
				AudioSource.PlayClipAtPoint (deathSound.clip, transform.position);
			} else {
				AudioSource.PlayClipAtPoint (painSound.clip, transform.position);
			}

			playerHealth.lives--;
			SpawnMeteor.meteorCounter--;
			Destroy(gameObject);
		}
	}
}
