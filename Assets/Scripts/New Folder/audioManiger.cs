using UnityEngine;
using UnityEngine.Audio;

public class audioManiger : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void setMasterVolume(float level)
    {
        // Convert 0-1 range to -80 to 0 dB
        float dB = (level - 1f) * 80f;
        mixer.SetFloat("MasterVolume", dB);
        PlayerPrefs.SetFloat("MasterVolume", level);
    }

    public void setVFXVolume(float level)
    {
        float dB = (level - 1f) * 80f;
        mixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolume", level);
    }

    public void setMusicVolume(float level)
    {
        float dB = (level - 1f) * 80f;
        mixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", level);
    }
}