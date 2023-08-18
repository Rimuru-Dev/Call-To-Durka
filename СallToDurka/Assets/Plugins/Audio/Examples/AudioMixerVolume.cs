using UnityEngine;
using UnityEngine.Audio;

namespace RimuruDev.Plugins.Audio.Examples
{
    public class AudioMixerVolume : MonoBehaviour
    {
        [SerializeField] private string _volumeParametr;
        [SerializeField] private AudioMixer _audioMixer;

        public void SetVolume(float value)
        {
            value = Mathf.Clamp(value, 0.0001f, 1f);
        
            _audioMixer.SetFloat( _volumeParametr, Mathf.Log10(value) * 20);
        }
    }
}
