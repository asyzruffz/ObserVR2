using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SatellitesManager))]
public class SatellitesManagerEditor : Editor {

    void OnSceneGUI()
    {
        SatellitesManager satManager = (SatellitesManager)target;
        Handles.color = Color.green;
        
		float angle = satManager.angleRange / 2;
		Vector3 offset = Vector3.up * satManager.radius * Mathf.Sin(angle * Mathf.Deg2Rad);
		float radius = satManager.radius * Mathf.Cos(angle * Mathf.Deg2Rad);

		Handles.DrawWireArc(satManager.transform.position + offset, Vector3.up, Vector3.forward, 360, radius);
		Handles.DrawWireArc(satManager.transform.position - offset, Vector3.up, Vector3.forward, 360, radius);
    }
}
