using UnityEngine;
using System.Collections;

public class ConnectionLine : MonoBehaviour {

    public GameObject start;
    public GameObject end;
    public float width = 0.1f;

    private LineRenderer lr;
    
    void Start () {
	    lr = GetComponent<LineRenderer>();
        lr.startWidth = width;
        lr.endWidth = width;
    }
    
    void Update () {
        lr.SetPosition(0, start.transform.position);
        lr.SetPosition(1, end.transform.position);
    }
}
