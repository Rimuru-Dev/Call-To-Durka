using System.Collections;
using UnityEngine;

namespace RimuruDev.Plugins.Audio.Core
{
    [RequireComponent(typeof(AudioSource))]
    public class SourceAudio : MonoBehaviour
    {
        public bool Loop;

        public float Volume
        {
            get => _audioSource.volume;
            set => _audioSource.volume = value;
        }

        public bool Mute
        {
            get => _audioSource.mute;
            set => _audioSource.mute = value;
        }

        public float Pitch
        {
            get => _audioSource.pitch;
            set => _audioSource.pitch = value;
        }

        public bool IsPlaying => _audioSource.isPlaying;

        private AudioSource _audioSource
        {
            get
            {
                if (_audioSourceCech == null)
                {
                    _audioSourceCech = GetComponent<AudioSource>();
                    _audioSource.clip = null;

                    Loop = _audioSource.loop;
                    _audioSource.loop = false;
                }

                return _audioSourceCech;
            }
        }

        private AudioSource _audioSourceCech;
        private Coroutine _playRoutine;

        private string _key;
        private bool _loadClip;

        private AudioClip _clip;

        private bool _isFocus = true;

        private bool _isPlaying = false;
        private float _lastTime;

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

        public void Play(string key)
        {
            _audioSource.Stop();

            if (string.IsNullOrEmpty(key))
            {
                Debug.LogError("key is empty, Source Audio PlaySound: " + gameObject.name);
                return;
            }

            if (_playRoutine != null)
            {
                StopCoroutine(_playRoutine);
            }

            _playRoutine = StartCoroutine(PlayRoutine(key));
        }

        private IEnumerator PlayRoutine(string key)
        {
            _loadClip = true;
            _key = key;
            _clip = null;

            _audioSource.Stop();
            _isPlaying = false;

            yield return AudioManagement.Instance.GetClip(key, audioClip => _clip = audioClip);

            if (_clip == null)
            {
                Debug.LogError("Audio Management not found clip at key: " + key + ",\n Source Audio PlaySound: " +
                               gameObject.name);
                yield break;
            }

            _audioSource.clip = _clip;
            _audioSource.Play();
            _isPlaying = true;
            _lastTime = 0;

            _loadClip = false;

            Debug.Log("Start play audio: " + key);
        }

        public void Play()
        {
            if (_clip != null)
            {
                if (_isPlaying)
                {
                    _audioSource.Stop();
                }

                _audioSource.time = 0;
                _audioSource.Play();
                _isPlaying = true;
                _lastTime = 0;

                Debug.Log("Start play audio: " + _key);
            }
            else
            {
                _isPlaying = false;
            }
        }

        public void Stop()
        {
            _audioSource.Stop();
            _isPlaying = false;
            _audioSource.time = 0;
        }

        private void Update()
        {
            HandleLoop();
        }

        private void HandleLoop()
        {
            if (Loop == false || _clip == null || _loadClip)
            {
                return;
            }

            if (_audioSource.time <= 0 && _isPlaying)
            {
                Debug.Log("Audio Loop: " + _key);

                _audioSource.time = 0;
                _audioSource.Play();
            }
        }

        private void Focus()
        {
            if (_isFocus == false && _isPlaying && _lastTime > 0)
            {
                _audioSource.time = _lastTime;
                Debug.Log(_key + " Last Time: " + _lastTime);
            }

            _isFocus = true;
        }

        private void UnFocus()
        {
            if (_isFocus && _isPlaying)
            {
                _lastTime = _audioSource.time;
                Debug.Log(_key + "Set Last Time: " + _lastTime);
            }

            _isFocus = false;
        }
    }
}