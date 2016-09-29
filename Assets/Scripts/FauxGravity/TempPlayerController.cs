using UnityEngine;
using System.Collections;

public class TempPlayerController : MonoBehaviour {

    public float moveSpeed;
    private Vector3 moveDir;
    
	void Update ()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.TransformDirection(moveDir) * moveSpeed * Time.fixedDeltaTime);
    }
}
