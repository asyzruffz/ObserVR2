using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

    private PlayerStatus status;

    void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        status = player.GetComponent<PlayerStatus>();
	}
    
	void Update () {
		
	}

	void OnTriggerEnter(Collider collidedObject)
	{
		if(collidedObject.gameObject.tag == "Player")
		{
            status.Hit();
		}
	}
}
