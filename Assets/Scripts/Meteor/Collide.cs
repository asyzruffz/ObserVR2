using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

    private Collider playerCollider;

	GameObject player;
	AudioSource[] aSource;
	AudioSource painSound;
	AudioSource deathSound;

	PlayerHealth playerHealth;
    
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		playerCollider = player.GetComponent<Collider>();
		playerHealth = player.GetComponentInChildren<PlayerHealth> ();

		//to play different audio
		aSource = GetComponents<AudioSource> ();
		painSound = aSource [0]; //will give error but still working
		deathSound = aSource [1];

	}
    
	void Update () {
		
	}

	void OnTriggerEnter(Collider collidedObject)
	{
		if(collidedObject.Equals(playerCollider))
		{
			if (playerHealth.lives == 1) {
				AudioSource.PlayClipAtPoint (deathSound.clip, transform.position);
			} else {
				AudioSource.PlayClipAtPoint (painSound.clip, transform.position);
			}

			playerHealth.lives--;
			GetComponent<Meteoroid>().OnHitPlayer();
		}
	}
}
