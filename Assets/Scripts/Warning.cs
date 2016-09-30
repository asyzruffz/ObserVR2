using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour {

    public Camera cam;

	void Start ()
    {
	    
	}
    
	void Update ()
    {
        var meteoroids = FindObjectsOfType<Meteoroid>();

        if(meteoroids.Length > 0)
        {
            //Debug.Log(cam.WorldToViewportPoint(meteoroids[0].gameObject.transform.position).ToString());
            Vector3 viewportPos = cam.WorldToViewportPoint(meteoroids[0].gameObject.transform.position);
            float screenX = Mathf.Clamp(viewportPos.x, 0, 1);
            float screenY = Mathf.Clamp(viewportPos.y, 0, 1);
            transform.localPosition = new Vector3(screenX, screenY);
        }
	}
}
