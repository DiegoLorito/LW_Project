using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CanEditMultipleObjects]
[CustomEditor(typeof(MonoBehaviour), true)]
public class ExposedScriptableEditor : Editor { }

#endif
