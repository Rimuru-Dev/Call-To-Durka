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
//         [SerializeField] private List<SourceAudio> sourceAudios;
//
//         private void OnEnable()
//         {
// #if UNITY_EDITOR
//             print("AudioClipEnableHelper - OnEnable");
// #endif
//         }
//
//         private void OnDisable()
//         {
// #if UNITY_EDITOR
//             print("AudioClipEnableHelper - OnDisable");
// #endif
//             foreach (var sourceAudio in sourceAudios.Where(x => x != null))
//             {
//                 sourceAudio.Stop();
//                 sourceAudio.Loop = false;
//             }
//         }
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