using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BurningMeteoroid : MonoBehaviour {

    [Range(0, 1)]
    public float burntRate;

    [Header("Effects")]
    public ParticleSystem fire;

    private Renderer surface;

	void Start () {
        burntRate = 0;
        surface = GetComponent<Renderer>();
    }
	
	void Update () {
        // Disable particles if not burning
        fire.gameObject.SetActive(burntRate > 0);

        // Change based on burntRate value
        fire.startSpeed = Mathf.Lerp(0.3f, 1.0f, burntRate);
        surface.material.SetFloat("_Blend", burntRate / 2);
	}
}
