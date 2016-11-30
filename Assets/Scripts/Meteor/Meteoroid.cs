using UnityEngine;
using System.Collections;

public class Meteoroid : MonoBehaviour {

    public GameObject destroyEffect;
    //public GameObject trailEffect;
    public GameObject[] variations;
    public float hardness = 100;

    private Selectable select;
    private bool exploded = false;
    private AudioSource explodeSound;
    private float maxHardness;

	void Awake () {
        int rng = Random.Range(0, variations.Length);
        GameObject model = (GameObject)Instantiate(variations[rng], transform.position, transform.rotation);
        model.transform.localScale = transform.localScale;
        model.transform.parent = transform;
        model.name = "Model";

        /*GameObject trail = (GameObject)Instantiate(trailEffect, transform.position, transform.rotation);
        trail.transform.parent = transform;
        trail.transform.localScale = Vector3.one;
        trail.name = "Burning";*/
    }

    void Start() {
        select = GetComponent<Selectable>();
        explodeSound = GetComponent<AudioSource>();
        Director.Instance.endEvent += OnExplode;
        FindObjectOfType<PlayerStatus>().hitEvent += OnHitPlayer;
        maxHardness = hardness;
    }
	
	void Update () {
	    if(select.connected) {
            hardness -= DamagePerSecond() * Time.deltaTime;
        }

        GetComponentInChildren<BurningMeteoroid>().burntRate = 1 - (hardness / maxHardness);

        if(hardness <= 0 && !exploded) {
            OnExplode();
            FindObjectOfType<Score>().score += 10;
        }
	}

    public void OnExplode() {
        exploded = true;

        var player = GameObject.FindWithTag("Player");
        if (player.GetComponent<CameraShake>() != null) {
            player.GetComponent<CameraShake>().ShakeCamera();
        }

        GameObject boom = (GameObject)Instantiate(destroyEffect, transform.position, transform.rotation);
        boom.transform.parent = transform.parent;
        AudioSource.PlayClipAtPoint(explodeSound.clip, transform.position);
        //explodeSound.Play();

        SelectionManager.Instance.ClearSelection();
        Director.Instance.endEvent -= OnExplode;
        FindObjectOfType<PlayerStatus>().hitEvent -= OnHitPlayer;
        MeteorManager.meteorCounter--;
        Destroy(gameObject);
    }

    public void OnHitPlayer() {
        SelectionManager.Instance.ClearSelection();
        Director.Instance.endEvent -= OnExplode;
        FindObjectOfType<PlayerStatus>().hitEvent -= OnHitPlayer;
        MeteorManager.meteorCounter--;
        Destroy(gameObject);
    }

    private float DamagePerSecond() {
        float damage = 0;

        foreach (GameObject node in SelectionManager.Instance.nodes) {
            if (node != null && node.gameObject.CompareTag("Satellite")) {
				damage += node.GetComponent<LaserController>().laserDamage;
            }
        }

        return damage;
    }
}
