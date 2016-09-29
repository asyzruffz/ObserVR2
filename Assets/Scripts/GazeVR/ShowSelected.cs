using UnityEngine;
using System.Collections;

public class ShowSelected : MonoBehaviour {

    public Material materialSelected;

    private Selectable self;
    private Material materialIdle;

    // Use this for initialization
    void Start () {
        self = GetComponent<Selectable>();
        materialIdle = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        if (self.selected || self.connected)
        {
            if (materialSelected != null)
                GetComponent<Renderer>().material = materialSelected;
        }
        else
        {
            GetComponent<Renderer>().material = materialIdle;
        }
    }
}
