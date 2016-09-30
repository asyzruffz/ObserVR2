using UnityEngine;
using System.Collections;

public class Meteoroid : MonoBehaviour {

    public GameObject destroyEffect;
    public GameObject[] variations;
    public float hardness = 100;

    private Selectable select;
    private bool exploded = false;

	void Awake ()
    {
        int rng = Random.Range(0, variations.Length);
        GameObject model = (GameObject)Instantiate(variations[rng], transform.position, Quaternion.identity);
        model.transform.localScale = transform.localScale;
        model.transform.parent = transform;
        model.name = "Model";
	}

    void Start()
    {
        select = GetComponent<Selectable>();
    }
	
	void Update ()
    {
	    if(select.connected)
        {
            hardness -= DamagePerSecond() * Time.deltaTime;
        }

        if(hardness <= 0 && !exploded)
        {
            OnExplode();
        }
	}

    public void OnExplode()
    {
        exploded = true;
        SpawnMeteor.meteorCounter--;
        GameObject boom = (GameObject)Instantiate(destroyEffect, transform.position, transform.rotation);
        boom.transform.parent = transform.parent;
        SelectionManager.Instance.ClearSelection();
        Destroy(gameObject);

        FindObjectOfType<PlayerHealth>().score += 10;
    }

    private float DamagePerSecond()
    {
        float damage = 0;

        foreach (GameObject node in SelectionManager.Instance.nodes)
        {
            if (node != null && node.gameObject.CompareTag("Satellite"))
            {
                damage += 15;
            }
        }

        return damage;
    }
}
