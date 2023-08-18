using System;
using UnityEngine;

namespace Plugins.Audio.Utils
{
    [Serializable]
    public class AudioDataProperty
    {
        [SerializeField] private string _id = "Null";
        [SerializeField] private string _key = "None";
    
        public string Key => _key;
    }
}