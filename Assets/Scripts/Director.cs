using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {



	void Start ()
    {
	
	}
	
	void Update ()
    {
        Transform first = null;
        Transform prev = null;
        foreach (var obj in SelectionManager.Instance.nodes)
        {
            if (obj.GetComponent<SphericalMovement>() != null)
            {
                // Set the first to wrap up later
                if (first == null)
                {
                    first = obj.transform;
                    prev = first;
                }
                
                prev.GetComponent<SphericalMovement>().FacingTowards(obj.transform);
                obj.GetComponent<SphericalMovement>().FacingTowards(first);
                prev = obj.transform;
            }
        }
    }
}
