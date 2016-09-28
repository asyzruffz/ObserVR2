using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

    public GameObject source;
    public int amount = 10;
    public float radius = 20;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < amount; ++i)
        {
            GameObject star = (GameObject)Instantiate(source);
            star.name = "Star";
            star.transform.parent = gameObject.transform;

            Vector3 direction = Random.onUnitSphere;
            star.GetComponent<SphericalMovement>().SetRotation(direction * 170.0f);
            star.GetComponent<SphericalMovement>().radius = radius;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
