using UnityEngine;
using System.Collections;

public class Meteoroid : MonoBehaviour {

    public GameObject destroyEffect;
    public GameObject[] variations;
    
	void Awake ()
    {
        int rng = Random.Range(0, variations.Length);
        GameObject model = (GameObject)Instantiate(variations[rng], transform.position, Quaternion.identity);
        model.transform.localScale = transform.localScale;
        model.transform.parent = transform;
        model.name = "Model";
	}
	
	void Update ()
    {
	
	}

    public void OnExplode()
    {
        GameObject boom = (GameObject)Instantiate(destroyEffect, transform.position, transform.rotation);
        boom.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}
