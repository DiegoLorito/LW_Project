using UnityEngine;


[CreateAssetMenu(fileName = "Template Data", menuName = "Scriptable Objects/Content/Thumbnail")]
public class SO_TemplateData : ScriptableObject
{
    public string code;
    public Sprite icon;
    public string templateName;
    public string sceneName;
}
