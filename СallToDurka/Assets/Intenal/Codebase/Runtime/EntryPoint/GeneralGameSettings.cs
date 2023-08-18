using System;
using UnityEngine;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [Serializable]
    public sealed class GeneralGameSettings
    {
        [field: SerializeField] public float TimeToStartAudioClip { get; private set; }
    }
}