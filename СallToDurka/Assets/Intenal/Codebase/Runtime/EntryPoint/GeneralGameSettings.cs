using System;
using RimuruDev.Plugins.Audio.Core;
using UnityEngine;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [Serializable]
    public sealed class GeneralGameSettings
    {
        [field: SerializeField] public float TimeToStartAudioClip { get; private set; }
        [field: SerializeField] public string SourceAudioKey { get; private set; }
        [field: SerializeField] public SourceAudio SourceAudio { get; private set; }
    }
}