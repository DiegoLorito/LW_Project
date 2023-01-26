using System;
using UnityEngine;

public static class AudioEvents
{
    public static event Action<VocabularyData> onSetVocabData;
    public static void SetVocabData(VocabularyData data) => onSetVocabData?.Invoke(data);

    public static event Action<AudioClip> onPlayVocab;
    public static void PlayVocab(AudioClip clip) => onPlayVocab?.Invoke(clip);

    public static event Action onPlayCorrect;
    public static void PlayCorrect() => onPlayCorrect?.Invoke();

    public static event Action onPlayIncorrect;
    public static void PlayIncorrect() => onPlayIncorrect?.Invoke();

    public static event Action onPlayCongratulation;
    public static void PlayCongratulation() => onPlayCongratulation?.Invoke();

    public static event Action onPlayFadeScene;
    public static void PlayFadeScene() => onPlayFadeScene?.Invoke();

    public static event Action<AudioClip> onPlaySFXOneShot;
    public static void PlaySFXOneShot(AudioClip clip)=> onPlaySFXOneShot?.Invoke(clip);
}
