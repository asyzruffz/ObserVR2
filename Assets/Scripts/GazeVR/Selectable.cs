using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Starable))]
public class Selectable : MonoBehaviour {

    public float activeTime = 1;
    public bool selected = false;
    public bool connected = false;

    private Starable status;
    private float activationTimer = 0;
    
	void Start () {
        status = GetComponent<Starable>();
	}

    void Update() {
        if (status.stared) {
            selected = true;
            activationTimer = 0;
        }

        if (selected) {
            activationTimer += Time.deltaTime;
            if (!connected) {
                SelectionManager.Instance.AddToSelection(gameObject);
            }
        }

        if (activationTimer > activeTime) {
            selected = false;
        }
    }

    public void Clear() {
        selected = false;
        connected = false;
    }
}
