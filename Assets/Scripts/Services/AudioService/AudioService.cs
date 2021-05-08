using Scripts;
using UnityEngine;

public class AudioService : Service
{
    private readonly SoundData _data;

    private AudioClip _soundClip;
    private AudioClip _musicClip;
    private AudioSource _soundSource;
    private AudioSource _musicSource;

    public AudioService()
    {
        _data = Data.Instance.SoundData;
        SetAudioSource();
    }

    private void SetAudioSource()
    {
        if (_soundSource != null) return;
        else
        {
            var sound = new GameObject("SoundManager");
            _soundSource = sound.AddComponent<AudioSource>();
            _soundSource.outputAudioMixerGroup = _data.soundAudioMixerGroup;
            Object.DontDestroyOnLoad(sound);
        }

        if (_musicSource != null) return;
        else
        {
            var music = new GameObject("MusicManager");
            _musicSource = music.AddComponent<AudioSource>();
            _musicSource.outputAudioMixerGroup = _data.musicAudioMixerGroup;
            Object.DontDestroyOnLoad(music);
        }
    }

    public void PlaySound(string audio)
    {
        _soundClip = CustomResources.Load<AudioClip>(audio);
        _soundSource.PlayOneShot(_soundClip);
    }

    public void PlayMusic(string audio)
    {
        if (_musicClip != null)
        {
            _musicClip.UnloadAudioData();
        }
        _musicClip = CustomResources.Load<AudioClip>(audio);
        _musicSource.PlayOneShot(_musicClip);
    }

    public void PauseMusic()
    {
        _musicSource.Pause();
    }

    public void UnPauseMusic()
    {
        _musicSource.UnPause();
    }
}