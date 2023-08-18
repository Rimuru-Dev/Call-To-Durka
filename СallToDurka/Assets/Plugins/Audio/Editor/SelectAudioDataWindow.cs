using System;
using System.Collections.Generic;
using Plugins.Audio.Core;
using UnityEditor;
using UnityEngine;
using AudioConfiguration = Plugins.Audio.Core.AudioConfiguration;

namespace Plugins.Audio.Editor
{
    public class SelectAudioDataWindow : EditorWindow
    {
        private Vector2 _scrollPosition;
        private AudioConfiguration _audioConfiguration;
        private string _search;
        private Action<AudioData> OnSelected;


        public static void Open(Action<AudioData> onSelected, Vector2 position)
        {
            var window = CreateInstance<SelectAudioDataWindow>();
            window.titleContent = new GUIContent("Search");

            Rect rect = new Rect();
            rect.position = position;
            rect.size = new Vector2(100, 170);
            
            window.OnSelected = onSelected;
            window.ShowAuxWindow();
        }

        private void OnGUI()
        {
            if (_audioConfiguration == null)
            {
                _audioConfiguration = AudioConfiguration.GetInstance();
            }
            
            if (_audioConfiguration.HasDatabase() == false)
            {
                return;
            }
            
            List<GUIContent> guiContents = new List<GUIContent>()
            {
                new GUIContent("None"), 
            };

            List<string> listID = new List<string>()
            {
                "Null",
            };
            
            _search = EditorGUILayout.TextField(_search, EditorStyles.toolbarSearchField);
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
            
            AudioDatabase database = _audioConfiguration.GetDatabase();

            if (GUILayout.Button("None", EditorStyles.toolbarButton, GUILayout.Height(20)))
            {
                OnSelected?.Invoke(null);
                Close();
            }
            
            foreach (AudioData data in database.Items)
            {
                if (string.IsNullOrEmpty(data.Key))
                {
                    continue;
                }

                guiContents.Add(new GUIContent(data.Key));
                listID.Add(data.ID);

                if (string.IsNullOrEmpty(_search) == false)
                {
                    if (data.Key.ToLower().Contains(_search.ToLower()) == false)
                    {
                        continue;
                    }
                }
                
                if (GUILayout.Button(data.Key, EditorStyles.toolbarButton, GUILayout.Height(20)))
                {
                    OnSelected?.Invoke(data);
                    Close();
                }

                GUILayout.Space(5);
            }

            EditorGUILayout.EndScrollView();
        }
    }
}
