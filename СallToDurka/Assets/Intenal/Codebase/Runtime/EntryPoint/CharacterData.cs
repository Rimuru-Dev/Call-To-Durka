using System;
using UnityEngine;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [Serializable]
    public sealed class CharacterData
    {
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public AudioClip AudioClip { get; private set; }
    }
}