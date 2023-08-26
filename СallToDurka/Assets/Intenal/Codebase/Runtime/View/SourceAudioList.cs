// ReSharper disable CommentTypo
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub:   https://github.com/RimuruDev
// **************************************************************** //

using UnityEngine;
using System.Collections.Generic;
using RimuruDev.Plugins.Audio.Core;

namespace RimuruDev.Intenal.Codebase.Runtime.View
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class SourceAudioList : MonoBehaviour
    {
        [field: SerializeField] public List<SourceAudio> SourceAudios;

        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate()
        {
            SourceAudios = new List<SourceAudio>();

            foreach (var sourceAudio in GetComponentsInChildren<SourceAudio>())
                SourceAudios.Add(sourceAudio);
        }
    }
}