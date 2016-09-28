using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    public Material materialIdle;
    public Material materialFocused;
    private bool stared = false;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (stared)
        {
            GetComponent<Renderer>().material = materialFocused;
        }
        else
        {
            GetComponent<Renderer>().material = materialIdle;
        }
    }

    public void StareEnter()
    {
        stared = true;
    }
        
    public void StareExit()
    {
        stared = false;
    }
}
