using UnityEngine;

public class SphericalMovement : MonoBehaviour
{
    public float radius = 10.0f;
    public bool fixedDirection = false;

    private float angle = 0.0f;
    private Vector3 direction = Vector3.one;
    private Quaternion rotation;
    private bool isStationary = true;
    
    void Update()
    {
        if (isStationary) return;

        direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle));
        UpdatePositionRotation();
    }

    public void SetRotation(Vector3 vec)
    {
        rotation = Quaternion.Euler(vec);
        isStationary = false;
    }

    private void UpdatePositionRotation()
    {
        transform.localPosition = rotation * Vector3.forward * radius;
    }
}