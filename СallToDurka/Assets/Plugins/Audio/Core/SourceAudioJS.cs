using System;
using System.Collections;
using UnityEngine;

namespace Plugins.Audio.Core
{
    public class SourceAudioJS : MonoBehaviour
    {
        [SerializeField] private bool _loop;
        [SerializeField, Range(0, 1)] private float _volume = 1;
        [SerializeField] private bool _mute = false;
    
        private AudioSource _audioSource;

        public bool Loop
        {
            get
            {
                return _loop;
            }
            set
            {
                _loop = value;

    #if !UNITY_WEBGL || UNITY_EDITOR
                _audioSource.loop = _loop;
                return;
    #endif
                WebAudio.SetSourceLoop(ID, _loop);
            }
        }

        public float Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = Mathf.Clamp(value, 0, 1);

    #if !UNITY_WEBGL || UNITY_EDITOR
                _audioSource.volume = _volume;
                return;
    #endif
                WebAudio.SetSourceVolume(ID, _volume);
            }
        }
        
        public bool Mute
        {
            get
            {
                return _mute;
            }
            set
            {
                _mute = value;

    #if !UNITY_WEBGL || UNITY_EDITOR
                _audioSource.mute = _mute;
                return;
    #endif
                WebAudio.SetSourceMute(ID, _mute);
            }
        }
        
        public string ID { get; private set; }

        private string _key;
        private Coroutine _playRoutine;
        private bool _loadClip;

        private void Awake()
        {
            ID = Guid.NewGuid().ToString();

    #if !UNITY_WEBGL || UNITY_EDITOR
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.volume = _volume;
            _audioSource.loop = _loop;
            _audioSource.mute = _mute;
            _audioSource.playOnAwake = false;
    #endif
        }
        
        private void OnEnable()
        {
            AppFocusHandle.OnFocus += Focus;
            AppFocusHandle.OnUnfocus += UnFocus;
        }

        private void OnDisable()
        {
            AppFocusHandle.OnFocus -= Focus;
            AppFocusHandle.OnUnfocus -= UnFocus;
        }
        
        private void OnDestroy()
        {
            WebAudio.DeleteSource(ID);
        }
        
        public void Play(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.LogError("key is empty, Source Audio PlaySound: " + gameObject.name);
                return;
            }
            
            _key = key;

            if (Application.isEditor || Application.platform != RuntimePlatform.WebGLPlayer)
            {
                _audioSource.Stop();
            
                if (_playRoutine != null)
                {
                    StopCoroutine(_playRoutine);
                }
            
                _playRoutine = StartCoroutine(PlayRoutine(key));
            
                return;
            }
            else
            {
                string clipPath = AudioManagement.Instance.GetClipPath(key);
                Debug.Log("CLIP PATH = " + clipPath);
                
                WebAudio.PlayAudio(ID, clipPath, _loop, _volume, _mute);
            }

            Debug.Log("Start play audio: " + key);
        }
        
        private IEnumerator PlayRoutine(string key)
        {
            _loadClip = true;
            AudioClip clip = null;
            
            _audioSource.Stop();
            
            yield return AudioManagement.Instance.GetClip(key, audioClip => clip = audioClip);

            if (clip == null)
            {
                Debug.LogError("Audio Management not found clip at key: " + key + ",\n Source Audio PlaySound: " + gameObject.name);
                yield break;
            }

            _audioSource.clip = clip;
            _audioSource.Play();

            _loadClip = false;
            
            Debug.Log("Start play audio: " + key);
        }

        public void Stop()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            _audioSource.Stop();
            
            return;
#endif
            WebAudio.StopSource(ID);
        }

        private void UnFocus()
        {
        }

        private void Focus()
        {
        }
    }

    public abstract class AudioProvider : MonoBehaviour
    {
        public abstract string CurrentKey { get; }
        public abstract float Volume { get; set; }
        public abstract bool Mute { get; set; }
        public abstract bool Loop { get; set; }
        public abstract float Pitch { get; set; }
        
        public abstract void Play(string key);
        public abstract void Stop();

        /*public abstract void Pause();
        public abstract void UnPause();*/
    }
}