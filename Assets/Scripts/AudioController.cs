using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [SerializeField] private AudioSource bgMusicSrc;
    [SerializeField] private AudioSource sfxSrc;

    [SerializeField] private AudioClip[] bgMusics;
    [SerializeField] private AudioClip[] sfxClips;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GetVolumeBG();
    }
    public void PlayBGMusic(int idBgMusic)
    {
        AudioClip clip = bgMusics[idBgMusic];
        bgMusicSrc.Stop();
        bgMusicSrc.clip = clip;
        bgMusicSrc.loop = true;
        bgMusicSrc.Play();

    }
    public void PlaySFX(int idSfx)
    {
        AudioClip clip = sfxClips[idSfx];
        sfxSrc.PlayOneShot(clip);
    }

    public void UpdateVolumeSFX(float value)
    {
        sfxSrc.volume = value;
        float volumeMusic = sfxSrc.volume;
        PlayerPrefs.SetFloat("VolumeSFX", volumeMusic);
    }
    public void UpdateVolumeBG(float value)
    {
        bgMusicSrc.volume = value;
        float volumeMusic = bgMusicSrc.volume;
        PlayerPrefs.SetFloat("VolumeBG", volumeMusic);
    }

    public float GetVolumeBG()
    {
        float volume = PlayerPrefs.GetFloat("VolumeBG", 0.5f);
        bgMusicSrc.volume = volume;
        return volume;
    }

    public float GetVolumeSFX()
    {
        float volume = PlayerPrefs.GetFloat("VolumeSFX", 0.5f);
        sfxSrc.volume = volume;
        return volume;
    }

}
