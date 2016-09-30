using UnityEngine;
using System.Collections;

public class SatellitesManager : MonoBehaviour
{
    public GameObject source;
    public int amount = 10;
    public float radius = 20;

    void Start()
    {
        for (int i = 0; i < amount; ++i)
        {
            GameObject satella = (GameObject)Instantiate(source);
            satella.name = "Satellite";
            satella.transform.parent = gameObject.transform;

            Vector3 direction = Random.onUnitSphere;
            satella.GetComponent<SphericalMovement>().SetRotation(direction * 170.0f);
            satella.GetComponent<SphericalMovement>().radius = radius;
        }
    }

    void Update()
    {

    }
}