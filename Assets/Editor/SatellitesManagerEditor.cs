using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SatellitesManager))]
public class SatellitesManagerEditor : Editor {

    void OnSceneGUI()
    {
        /*SatellitesManager satManager = (SatellitesManager)target;
        Handles.color = Color.yellow;
        
        Handles.DrawWireArc(satManager.transform.position, Vector3.up, Vector3.forward, 360, satManager.radius);
        Handles.DrawWireArc(satManager.transform.position, Vector3.forward, Vector3.up, 360, satManager.radius);
        Handles.DrawWireArc(satManager.transform.position, Vector3.right, Vector3.up, 360, satManager.radius);*/
    }
}
