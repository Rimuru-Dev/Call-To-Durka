using System;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace Plugins.Audio.Core
{
    public static class AppFocusHandle
    {
        public static event Action OnFocus;
        public static event Action OnUnfocus;
        
        [DllImport("__Internal")]
        private static extern void FocusAppHandleInit(Action focus, Action unFocus);

        private static bool _isInitialize = false;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Initialize()
        {
            if (_isInitialize)
            {
                return;
            }

            _isInitialize = true;

            if (Application.isEditor || Application.platform != RuntimePlatform.WebGLPlayer)
            {
                return;
            }

/*
#if UNITY_EDITOR || !UNITY_WEBGL
            return;
#endif
*/

            FocusAppHandleInit(Focus, UnFocus);
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void Focus()
        {
            OnFocus?.Invoke();
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void UnFocus()
        {
            OnUnfocus?.Invoke();
        }
    }
}