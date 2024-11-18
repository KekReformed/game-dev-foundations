using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private TMP_Text ValueText;
    [SerializeField] private AudioMixMode MixMode; 

    private void start()
    {
        Mixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20));
    }

    public void OnChangeSLider(float Value)
    {
        ValueText.SetText($"{Value.ToString("f1")}");

        switch(MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = Value;
                break;
            case AudioMixMode.LinearMixerVolume:
                Mixer.SetFloat("Volume", (-80 + Value * 100));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                break;

        }
    }

    void update()
    {
        PlayerPrefs.SetFloat("Volume", Value);
        PlayerPrefs.Save();
    }



    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume

    }
}
