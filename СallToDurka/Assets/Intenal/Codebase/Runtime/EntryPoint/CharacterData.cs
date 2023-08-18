using System;
using RimuruDev.Plugins.Audio.Core;
using UnityEngine;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [Serializable]
    public sealed class CharacterData
    {
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public string AudioClipKey { get; private set; }
        [field: SerializeField] public SourceAudio AudioClip { get; private set; }
    }
}