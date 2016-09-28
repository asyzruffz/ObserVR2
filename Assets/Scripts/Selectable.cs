using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {

    public float activeTime = 1;
    public bool selected = false;
    public bool connected = false;

    private Starable status;
    private float activationTimer = 0;

	// Use this for initialization
	void Start () {
        status = GetComponent<Starable>();
	}
	
	// Update is called once per frame
	void Update () {
        if (status.stared)
        {
            selected = true;
            activationTimer = 0;
        }

        if (activationTimer > activeTime)
            selected = false;

        if (selected)
        {
            activationTimer += Time.deltaTime;
            if (!connected)
                SelectionManager.Instance.AddToSelection(gameObject);
        }
    }
}
