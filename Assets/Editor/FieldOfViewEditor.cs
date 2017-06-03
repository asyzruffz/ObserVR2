using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor {

	void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.green;

        float halfAngle = fov.viewAngle / 2;

        Handles.DrawWireArc(fov.transform.position, Vector3.up, fov.DirFromAngle (-halfAngle, false), fov.viewAngle, fov.viewRadius);
        Handles.DrawWireArc(fov.transform.position + fov.transform.forward * Mathf.Cos (halfAngle * Mathf.Deg2Rad) * fov.viewRadius, -fov.transform.forward, -fov.transform.right, 180, Mathf.Sin (halfAngle * Mathf.Deg2Rad) * fov.viewRadius);

        Vector3 viewAngleLeft = fov.DirFromAngle(-halfAngle, false);
        Vector3 viewAngleRight = fov.DirFromAngle(halfAngle, false);
        Vector3 viewAngleTop = Quaternion.AngleAxis (-halfAngle, fov.transform.right) * fov.transform.forward;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleLeft * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleRight * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleTop * fov.viewRadius);

        Handles.color = Color.red;
        foreach(Transform visibleTarget in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.transform.position);
        }
    }
}
