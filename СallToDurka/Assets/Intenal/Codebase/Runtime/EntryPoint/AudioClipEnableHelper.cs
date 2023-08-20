using RimuruDev.Plugins.Audio.Core;
using UnityEngine;

// using System.Collections.Generic;
// using System.Linq;
// using RimuruDev.Plugins.Audio.Core;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class AudioClipEnableHelper : MonoBehaviour
    {
        public GameObject audioComponent;

//         [SerializeField] private List<SourceAudio> sourceAudios;
//
//         private void OnEnable()
//         {
// #if UNITY_EDITOR
//             print("AudioClipEnableHelper - OnEnable");
// #endif
//         }
//
        private void OnDisable()
        {
            audioComponent.SetActive(false);
            print("AudioClipEnableHelper - OnDisable");

            foreach (var audioSource in FindObjectsOfType<AudioSource>(true))
                audioSource.Stop();

            foreach (var sourceAudio in FindObjectsOfType<SourceAudio>(true))
            {
                sourceAudio.Stop();
                // sourceAudio._audioSource.time = 0;
            }

            audioComponent.SetActive(true);

// #if UNITY_EDITOR
//             
// #endif
//             foreach (var sourceAudio in sourceAudios.Where(x => x != null))
//             {
//                 sourceAudio.Stop();
//                 sourceAudio.Loop = false;
//             }
        }
//
// #if UNITY_EDITOR
//         [System.Diagnostics.Conditional("DEBUG")]
//         private void OnValidate()
//         {
//             sourceAudios = new List<SourceAudio>();
//
//             foreach (var sourceAudio in FindObjectsOfType<SourceAudio>())
//                 sourceAudios.Add(sourceAudio);
//         }
// #endif
    }
}