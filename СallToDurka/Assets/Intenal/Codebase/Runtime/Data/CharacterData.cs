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
    public sealed class CharacterData
    {
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public string AudioClipKey { get; private set; }
        [field: SerializeField] public SourceAudio AudioClip { get; private set; }
    }
}