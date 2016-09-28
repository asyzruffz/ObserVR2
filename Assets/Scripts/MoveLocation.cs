using UnityEngine;
using System.Collections;

public class MoveLocation : MonoBehaviour
{

    public CamPositionManager manager;
    public int teleportIndex = -1;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("Trigger detected!");
        if (obj.gameObject.tag == "Player")
        {
            if (teleportIndex >= 0)
                manager.MoveCamera(teleportIndex);
        }
    }
}
