using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {

    private float lifetime = 5;
    private float timer = 0;
    
	void Update () {
        if (timer > lifetime)
            Destroy(gameObject);

        timer += Time.deltaTime;
	}
}
