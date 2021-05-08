using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SoundData", menuName = "Data/Sound/SoundData")]
public sealed class SoundData : ScriptableObject
{
    public AudioMixerGroup musicAudioMixerGroup;
    public AudioMixerGroup soundAudioMixerGroup;
}