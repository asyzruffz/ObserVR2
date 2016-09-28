using UnityEngine;
using System.Collections;

public class ConnectionLine : MonoBehaviour {

    public GameObject start;
    public GameObject end;
    public float width = 0.1f;

    private LineRenderer lr;

    // Use this for initialization
    void Start () {
	    lr = GetComponent<LineRenderer>();
        lr.SetWidth(width, width);
        //gameObject.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        //gameObject.SetColors(color, color);
    }

    // Update is called once per frame
    void Update () {
        lr.SetPosition(0, start.transform.position);
        lr.SetPosition(1, end.transform.position);
    }
}
