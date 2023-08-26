// ReSharper disable CommentTypo
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub:   https://github.com/RimuruDev
// **************************************************************** //

using System;
using UnityEngine;
using RimuruDev.Plugins.Audio.Core;

namespace RimuruDev.Intenal.Codebase.Runtime.Data
{
    [Serializable]
    public sealed class MainRingtone
    {
        [field: SerializeField] public string SourceAudioKey { get; private set; }
        [field: SerializeField] public SourceAudio SourceAudio { get; private set; }
    }
}