using UnityEngine;

public class ControladorAvatar : MonoBehaviour
{
    public UnityEngine.UI.Image avatar;

    private void Awake()
    {
        GameEvents.onSetAvatarSprite += SetAvatarSprite;
    }
    private void SetAvatarSprite(Sprite sprite)
    {
        avatar.sprite = sprite;
    }
    private void OnDestroy()
    {
        GameEvents.onSetAvatarSprite -= SetAvatarSprite;
    }
}
