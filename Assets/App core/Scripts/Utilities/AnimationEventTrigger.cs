using UnityEngine;
using UnityEngine.Events;

public class AnimationEventTrigger : MonoBehaviour
{
    public UnityEvent[] eventTrigger;

    public AudioSource audioSource;

    public void TriggerEvent(int index) => eventTrigger[index]?.Invoke();
    public void PlayAudioClip(AudioClip clip)
    {
        if(audioSource == null)
        {
            AudioEvents.PlaySFXOneShot(clip);
            return;
        }

        audioSource.PlayOneShot(clip);
    }
}
