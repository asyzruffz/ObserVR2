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

    public void Translate(float x, float y)
    {
        Vector3 perpendicular = new Vector3(-direction.y, direction.x);
        Quaternion verticalRotation = Quaternion.AngleAxis(y * Time.deltaTime, perpendicular);
        Quaternion horizontalRotation = Quaternion.AngleAxis(x * Time.deltaTime, fixedDirection ? Vector3.up : direction);
        rotation *= horizontalRotation * verticalRotation;
    }

    public void Rotate(float amount)
    {
        angle += amount * Mathf.Deg2Rad * Time.deltaTime;
    }

    private void UpdatePositionRotation()
    {
        transform.localPosition = rotation * Vector3.forward * radius;
        if (fixedDirection)
        {
            Vector3 upwards = transform.localPosition.normalized;
            Vector3 forward = Vector3.up;
            //Vector3 forward = new Vector3(upwards.z, -upwards.x, -upwards.y); testing for better alignment failed
            transform.rotation = Quaternion.LookRotation(forward, upwards);
        }
        else
        {
            transform.rotation = rotation * Quaternion.LookRotation(direction, Vector3.forward);
        }
    }
}