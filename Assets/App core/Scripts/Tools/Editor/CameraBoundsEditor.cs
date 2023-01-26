using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

[CustomEditor(typeof(CameraFit)), CanEditMultipleObjects]
public class CameraBoundsEditor : Editor
{
    private BoxBoundsHandle m_BoundsHandle = new BoxBoundsHandle();

    // the OnSceneGUI callback uses the Scene view camera for drawing handles by default
    protected void OnSceneGUI()
    {
        CameraFit boundsExample = (CameraFit)target;

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
            newBounds.size = m_BoundsHandle.size;
            boundsExample.bounds = newBounds;
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CameraFit script = (CameraFit)target;

        EditorGUILayout.Space(10);
        if (GUILayout.Button("Fit to Camera Bounds"))
        {
            script.FitToCameraBounds();
            SceneView.RepaintAll();
        }
    }
}
