using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

[CustomEditor(typeof(CameraFitHorizontal)), CanEditMultipleObjects]
public class CameraBoundsHorizontalEditor : Editor
{
    private BoxBoundsHandle m_BoundsHandle = new BoxBoundsHandle();

    // the OnSceneGUI callback uses the Scene view camera for drawing handles by default
    protected void OnSceneGUI()
    {
        CameraFitHorizontal boundsExample = (CameraFitHorizontal)target;

        // copy the target object's data to the handle
        m_BoundsHandle.center = boundsExample.bounds.center;
        m_BoundsHandle.size = boundsExample.bounds.size;

        // draw the handle
        Handles.color = Color.cyan;
        EditorGUI.BeginChangeCheck();
        m_BoundsHandle.DrawHandle();
        if (EditorGUI.EndChangeCheck())
        {
            // record the target object before setting new values so changes can be undone/redone
            Undo.RecordObject(boundsExample, "Change Bounds");

            // copy the handle's updated data back to the target object
            Bounds newBounds = new Bounds();
            newBounds.center = m_BoundsHandle.center;

            //Vector3 size = new Vector3();

            //size.x = m_BoundsHandle.size.x;
            //size.y = boundsExample

            newBounds.size = m_BoundsHandle.size;
            boundsExample.bounds = newBounds;
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CameraFitHorizontal script = (CameraFitHorizontal)target;

        EditorGUILayout.Space(10);
        if (GUILayout.Button("Fit to Camera Bounds"))
        {
            script.FitToCameraBounds();
            SceneView.RepaintAll();
        }
    }
}
