using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Warning : MonoBehaviour {

    public Camera cam;
    public GameObject indicator;

    private int num = 5; 
    private List<GameObject> instances = new List<GameObject>();

	void Start ()
    {
        for (int i = 0; i < num; i++)
        {
            GameObject inst = Instantiate(indicator);
            inst.transform.SetParent(transform);
            inst.name = "Warning";
            inst.transform.localScale = Vector3.one;
            inst.SetActive(false);
            instances.Add(inst);
        }
    }
    
	void Update ()
    {
        var meteoroids = FindObjectsOfType<Meteoroid>();
        for(int i = 0; i < num; i++)
        {
            if(i < meteoroids.Length)
            {
                instances[i].SetActive(true);

                Vector3 viewportPos = cam.WorldToViewportPoint(meteoroids[i].gameObject.transform.position);
                float screenX = Mathf.Clamp(viewportPos.x, 0, 1) * 2 - 1;
                float screenY = Mathf.Clamp(viewportPos.y, 0, 1) * 2 - 1;

                if(viewportPos.z < 0)
                {
                    screenX = -Mathf.Sign(screenX);
                    screenY = -screenY;
                }

                instances[i].transform.localPosition = new Vector3(screenX * 180, screenY * 180, transform.localPosition.z);
            }
            else
            {
                instances[i].SetActive(false);
            }

        }
	}
}
