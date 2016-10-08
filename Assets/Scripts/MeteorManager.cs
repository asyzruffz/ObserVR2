using UnityEngine;
using System.Collections;

public class MeteorManager : MonoBehaviour {

	public float spawnTime; //Time until next meteor spawned
	public float meteorLimit; //to limit number of meteor flying towrds player
	public GameObject meteor; //for the static variable of meteorCounter
	public static int meteorCounter; //Collide.cs will use it too
	public FauxGravityAttractor player; //gravity attractor purpose

	public float radius;  //the radius of meteor will spawned
    [Range(0,180)]
    public float angleRange = 180f;

	public float gravityChangeInterval; //the time until gravity is increased
	public float gravityChange; //the speed of gravity increased
    
	void Start () {
        if(player == null)
        {
            player = FindObjectOfType<FauxGravityAttractor>();
        }
        Director.Instance.startEvent += OnStartGame;
        Director.Instance.endEvent += OnStopGame;
    }
	
	void Update () {
        
	}

    void OnStartGame()
    {
        meteorCounter = 0;
        player.gravity = 0.1f;

        Invoke("spawn", 3);
        Invoke("gravity", gravityChangeInterval + 3);
    }

    void OnStopGame()
    {
        CancelInvoke("spawn");
        CancelInvoke("gravity");
    }

    //spawn meteor
    void spawn()
	{
		if (meteorCounter < meteorLimit) {

            Vector3 meteorPos;
            do { // Limit the vertical angle to spawn
                meteorPos = Random.onUnitSphere * radius;
            } while (Mathf.Abs(meteorPos.y) > radius * Mathf.Sin(angleRange * 0.5f * Mathf.Deg2Rad));

            GameObject meteorObject = (GameObject)Instantiate(meteor, meteorPos, Quaternion.identity);
            meteorObject.name = "Meteor";
            meteorObject.transform.parent = gameObject.transform;
            meteorCounter++;
		}
        
        Invoke("spawn", spawnTime);
    }

	//change gravity
	void gravity()
	{
		player.gravity += gravityChange;
        Invoke("gravity", gravityChangeInterval);
    }
}
