using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SpawnMeteor))]
public class SpawnMeteorEditor : Editor {

    void OnSceneGUI()
    {
        SpawnMeteor spawner = (SpawnMeteor)target;
        Handles.color = Color.yellow;

        float angle = spawner.angleRange / 2;
        Vector3 offset = Vector3.up * spawner.radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        float radius = spawner.radius * Mathf.Cos(angle * Mathf.Deg2Rad);

        Handles.DrawWireArc(spawner.transform.position + offset, Vector3.up, Vector3.forward, 360, radius);
        Handles.DrawWireArc(spawner.transform.position - offset, Vector3.up, Vector3.forward, 360, radius);
        Handles.DrawLine(spawner.transform.position, spawner.transform.position + offset + Vector3.forward * radius);
        Handles.DrawLine(spawner.transform.position, spawner.transform.position - offset + Vector3.forward * radius);
    }
}
