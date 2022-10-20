using UnityEngine;
using DG.Tweening;
using System.Collections;

public class AudioManagerCustom : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceVocab;
    [SerializeField] private AudioSource _sourceSFX;
    [SerializeField] private AudioSource _sourceMusic;

    //[Header("SFX")]
    //[SerializeField] private GameObject _objSFX;
    //[SerializeField] private SO_AudioClip[] _clipsSFX;

    [Header("Common Clips")]
    [SerializeField] private AudioClip _clipCorrect;
    [SerializeField] private AudioClip _clipIncorrect;
    [SerializeField] private AudioClip _clipStar;
    [SerializeField] private AudioClip _clipFadeScene;
    [SerializeField] private AudioClip[] _clipCongratulation;


    public AudioClip ClipCorrect { get => _clipCorrect;}
    public AudioClip ClipIncorrect { get => _clipIncorrect;}
    public AudioClip ClipStar { get => _clipStar;}
    public AudioClip ClipCongratulation { get => _clipCongratulation.RandomItem(); }

    private void Awake()
    {
        AudioEvents.onPlaySFXOneShot += PlaySFXOneShot;
        AudioEvents.onPlayVocab += PlayVocab;
        AudioEvents.onPlayCorrect += PlayCorrect;
        AudioEvents.onPlayIncorrect += PlayIncorrect;
        AudioEvents.onPlayCongratulation += PlayCongratulation;
        AudioEvents.onPlayFadeScene += PlayFadeScene;

        _sourceVocab.loop = false;
        _sourceSFX.loop = false;


        if (Helper.IsIpadScreen)
        {
            //Aqui va tu codigo de ipad
        }
        else
        {
            //Aqui va tu codigo normal
        }
    }

    public void PlayCorrect()
    {
        _sourceSFX.clip = _clipCorrect;
        _sourceSFX.Play();
    }
    public void PlayIncorrect()
    {
        _sourceSFX.clip = _clipIncorrect;
        _sourceSFX.Play();
    }
    public void PlayStar()
    {
        _sourceSFX.clip = _clipStar;
        _sourceSFX.Play();
    }
    public void PlayCongratulation()
    {
        _sourceSFX.clip = _clipCongratulation.RandomItem();
        _sourceSFX.Play();
    }
    public void PlayFadeScene()=> _sourceSFX.PlayOneShot(_clipFadeScene);
    public void PlaySFXOneShot(AudioClip clip)=> _sourceSFX.PlayOneShot(clip);
    public void PlaySequence(AudioClip[] clips)
    {
        StartCoroutine(Sequence());

        IEnumerator Sequence()
        {
            for (int i = 0; i < clips.Length; i++)
            {
                AudioClip clip = clips[i];
                float clipLength = clip.length;

                _sourceSFX.clip = clip;
                _sourceSFX.Play();

                yield return Helper.GetWait(clipLength);
            }
        }
    }
    public void PlayVocab(AudioClip clip)
    {
        if(clip == null)
        {
            Debug.Log("No hay Clip");
            return;
        }

        _sourceVocab.clip = clip;
        _sourceVocab.Play();
    }

    public void StopVocab() => _sourceVocab.Stop();

    private void OnDestroy()
    {
        AudioEvents.onPlaySFXOneShot -= PlaySFXOneShot;
        AudioEvents.onPlayVocab -= PlayVocab;
        AudioEvents.onPlayCorrect -= PlayCorrect;
        AudioEvents.onPlayIncorrect -= PlayIncorrect;
        AudioEvents.onPlayCongratulation -= PlayCongratulation;
        AudioEvents.onPlayFadeScene -= PlayFadeScene;
    }
}
