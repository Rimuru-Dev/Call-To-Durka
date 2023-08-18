using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Plugins.Audio.Core
{
    [CreateAssetMenu(fileName = "Audio Management", menuName = "Audio/Management")]
    public class AudioConfiguration : ScriptableObject
    {
        [SerializeField] private AudioDatabase _database;
        
        private const string PATH = "Assets/Resources";
        private const string NAME = "AudioManagementSettings";

        private static AudioConfiguration _instance;

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
#endif
        public static AudioConfiguration GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            _instance = Resources.Load<AudioConfiguration>(NAME);
            
#if UNITY_EDITOR
            string assetPath = PATH + "/" + NAME + ".asset";
            
            if (_instance == null)
            {
                if (AssetDatabase.IsValidFolder("Assets/Resources") == false)
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }
                
                _instance = CreateInstance<AudioConfiguration>();
                AssetDatabase.CreateAsset(_instance, assetPath);
                AssetDatabase.SaveAssetIfDirty(_instance);
            }
#endif
            
            return _instance;
        }

#if !UNITY_WEBGL || UNITY_EDITOR
        public AudioClip GetClip(string key)
        {
            AudioDatabase database = GetDatabase();

            return database.GetClip(key);
        }
#endif

        public string GetClipPath(string key)
        {
            AudioDatabase database = GetDatabase();

            return database.GetClipPath(key);
        }

        public AudioDatabase GetDatabase()
        {
            AudioConfiguration audioConfiguration = GetInstance();

            if (audioConfiguration._database != null)
            {
                return audioConfiguration._database;
            }

            throw new Exception("Audio Management: database has not been created");
        }

        public void SetDatabase(AudioDatabase database)
        {
            AudioConfiguration audioConfiguration = GetInstance();
            audioConfiguration._database = database;
        }

        public bool HasDatabase()
        {
            return _database != null;
        }
    }
}