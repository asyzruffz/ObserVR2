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
        Director.Instance.endEvent += OnExplode;
        FindObjectOfType<PlayerStatus>().hitEvent += OnHitPlayer;
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
            FindObjectOfType<Score>().score += 10;
        }
	}

    public void OnExplode()
    {
        exploded = true;

        var player = GameObject.FindWithTag("Player");
        if (player.GetComponent<CameraShake>() != null)
        {
            player.GetComponent<CameraShake>().ShakeCamera();
        }

        GameObject boom = (GameObject)Instantiate(destroyEffect, transform.position, transform.rotation);
        boom.transform.parent = transform.parent;

        SelectionManager.Instance.ClearSelection();
        Director.Instance.endEvent -= OnExplode;
        FindObjectOfType<PlayerStatus>().hitEvent -= OnHitPlayer;
        SpawnMeteor.meteorCounter--;
        Destroy(gameObject);
    }

    public void OnHitPlayer()
    {
        SelectionManager.Instance.ClearSelection();
        Director.Instance.endEvent -= OnExplode;
        FindObjectOfType<PlayerStatus>().hitEvent -= OnHitPlayer;
        SpawnMeteor.meteorCounter--;
        Destroy(gameObject);
    }

    private float DamagePerSecond()
    {
        float damage = 0;

        foreach (GameObject node in SelectionManager.Instance.nodes)
        {
            if (node != null && node.gameObject.CompareTag("Satellite"))
            {
                damage += node.GetComponent<SatelliteController>().laserDamage;
            }
        }

        return damage;
    }
}
