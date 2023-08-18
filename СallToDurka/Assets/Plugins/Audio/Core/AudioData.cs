using System;
using UnityEngine;

namespace Plugins.Audio.Core
{
    [Serializable]
    public class AudioData
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        public AudioClip Clip;
#endif

        public string Key;
        public string FolderPath;
        public string Name;
        public bool Preload = true;
        
        public string ID => _id;

        [SerializeField] private string _id;
        
        
        public AudioData()
        {
            if (string.IsNullOrEmpty(_id))
            {
                _id = Guid.NewGuid().ToString();
            }
        }

        public void GenerateID()
        {
            if (string.IsNullOrEmpty(_id))
            {
                _id = Guid.NewGuid().ToString();
            }
        }
    }
}