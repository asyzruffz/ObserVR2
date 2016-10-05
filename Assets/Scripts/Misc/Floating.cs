using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {

    public enum WaveAxis {
        X, Y, Z
    }

    public float amplitude;
    public float speed;
    public float degreeOffset;
    public WaveAxis waveDirection = WaveAxis.Y;

    void Start () {
	
	}
	
	void Update () {
        float wave = Mathf.Sin(Time.time * speed + degreeOffset * Mathf.Deg2Rad) * amplitude;

        switch (waveDirection)
        {
            case WaveAxis.X:
                transform.localPosition = new Vector3(wave, transform.localPosition.y, transform.localPosition.z);
                break;
            case WaveAxis.Y:
                transform.localPosition = new Vector3(transform.localPosition.x, wave, transform.localPosition.z);
                break;
            case WaveAxis.Z:
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, wave);
                break;
        }
	}
}
