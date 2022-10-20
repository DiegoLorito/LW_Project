using UnityEngine;

public class RepeatingVocabClip : MonoBehaviour
{
    [HideInInspector]public AudioClip clipVocab;

    [SerializeField]
    private float _rate;

    private float _counter;
    private bool _canCount;

    private void Update()
    {
        if (!_canCount) return;

        _counter += Time.deltaTime;

        

        if(_counter >= _rate)
        {
            _counter = 0;
            AudioEvents.PlayVocab(clipVocab);

            Debug.Log("Play");
        }
    }
    public void RestartCounter() => _counter = 0;
    public void StopCounter() => _canCount = false;
    public void StartCounter() => _canCount = true;
}
