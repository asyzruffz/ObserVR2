using UnityEngine;
using System.Collections;

public class SpawnMeteor : MonoBehaviour {
	public float spawnTime; //Time until next meteor spawned
	public float meteorLimit; //to limit number of meteor flying towrds player
	public GameObject meteor; //for the static variable of meteorCounter
	public static int meteorCounter; //Collide.cs will use it too
	public GameObject player; //for gravity attractor purpose
	public FauxGravityAttractor attractor; //gravity attractor purpose
	public float radius;  //the radius of meteor will spawned

	public float gravityChangeInterval; //the time until gravity is increased
	public float gravityChange; //the speed of gravity increased
    
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		attractor = player.GetComponent<FauxGravityAttractor> ();

		InvokeRepeating ("spawn", spawnTime, spawnTime);
		InvokeRepeating ("gravity", gravityChangeInterval, gravityChangeInterval);
	}
	
	void Update () {
		
	}

	//spawn meteor
	void spawn()
	{
		if (meteorCounter < meteorLimit) {
            Vector3 meteorPos = Random.onUnitSphere * radius;
            GameObject meteorObject = (GameObject)Instantiate(meteor, meteorPos, Quaternion.identity);
            meteorObject.name = "Meteor";
            meteorObject.transform.parent = gameObject.transform;
            meteorCounter++;
		}
	}

	//change gravity
	void gravity()
	{
		attractor.gravity += gravityChange;
	}
}
