using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public UnityEvent[] events;

    public void TriggerEvent(int index)=> events[index]?.Invoke();
}
