using System.Runtime.InteropServices;
using UnityEngine;

namespace Plugins.Audio.Core
{
    public static class WebAudio
    {
        private static float _volume = 1;
        
        public static float Volume
        {
            get => _volume;
            set => SetVolume(value);
        }

        private static void SetVolume(float value)
        {
            if (_volume.Equals(value))
            {
                return;
            }

            _volume = value;
            
#if !UNITY_WEBGL || UNITY_EDITOR
            AudioListener.volume = value;
            return;
#endif
            
            SetGlobalVolume(value);
        }
        
        public static void SetSourceVolume(string sourceID, float value)
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            return;
#endif

            value = Mathf.Clamp(value, 0, 1);
            SetAudioSourceVolume(sourceID, value);
        }
    
        public static void SetSourceMute(string sourceID, bool value)
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            return;
#endif

            SetAudioSourceMute(sourceID, value);
        }

        public static void Mute(bool value)
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            return;
#endif

            MuteExtern(value);
        }

        public static void PlayAudio(string sourceID, string clipPath, bool loop, float volume, bool mute)
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            return;
#endif

            PlayAudioExtern(sourceID, clipPath, loop, volume, mute);
        }

        public static void SetSourceLoop(string sourceID, bool loop)
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            return;
#endif

            SetSourceLoopExtern(sourceID, loop);
        }

        public static void StopSource(string sourceID)
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            return;
#endif
            StopAudioSource(sourceID);
        }
    
        public static void DeleteSource(string sourceID)
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            return;
#endif
        
            DeleteAudioSource(sourceID);
        }

        public static void SetSourcePitch(string sourceID, float value)
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            return;
#endif
            
            SetAudioSourcePitch(sourceID, value);
        }

        [DllImport("__Internal")]
        private static extern void SetGlobalVolume(float value);
        
        [DllImport("__Internal")]
        private static extern void MuteExtern(bool value);

        [DllImport("__Internal")]
        private static extern void PlayAudioExtern(string sourceID, string clipPath, bool loop, float volume, bool mute);

        [DllImport("__Internal")]
        private static extern void SetSourceLoopExtern(string sourceID, bool loop);

        [DllImport("__Internal")]
        private static extern void SetAudioSourceVolume(string sourceID, float value);

        [DllImport("__Internal")]
        private static extern void SetAudioSourceMute(string sourceID, bool value);
    
        [DllImport("__Internal")]
        private static extern void StopAudioSource(string sourceID);

        [DllImport("__Internal")]
        private static extern void DeleteAudioSource(string sourceID); 
        
        [DllImport("__Internal")]
        private static extern void SetAudioSourcePitch(string sourceID, float value);
    }
}