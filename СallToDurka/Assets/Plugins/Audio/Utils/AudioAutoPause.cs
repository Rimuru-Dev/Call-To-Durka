using Plugins.Audio.Core;
using UnityEngine;

namespace Plugins.Audio.Utils
{
    public class AudioAutoPause : MonoBehaviour
    {
        private static AudioAutoPause _instance;
        
        private bool _isFocused = true;
        
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
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

        private void Focus()
        {
            if (_isFocused == false)
            {
                AudioListener.pause = false;
                WebAudio.Mute(false);

                _isFocused = true;

                Debug.Log("Unpause Audio");
            }
        }

        private void UnFocus()
        {
            if (_isFocused)
            {
                AudioListener.pause = true;
                WebAudio.Mute(true);
                
                _isFocused = false;
                
                Debug.Log("Pause Audio");
            }
        }
    }
}