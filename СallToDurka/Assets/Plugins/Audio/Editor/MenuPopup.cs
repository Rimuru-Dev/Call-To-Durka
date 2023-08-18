using System;
using UnityEditor;
using UnityEngine;

namespace Plugins.Audio.Editor
{
    public class MenuPopup : EditorWindow
    {
        private event Action _onCreateDatabase;
        private event Action _onOpenDatabase;

        public void OnCreateDatabase(Action action)
        {
            _onCreateDatabase = action;
        }

        public void OnOpenDatabase(Action action)
        {
            _onOpenDatabase = action;
        }
            
        public void OnGUI()
        {
            if (GUILayout.Button(GUIContent.none, EditorStyles.toolbarButton))
            {
                Close();
                _onCreateDatabase?.Invoke();
            }

            Rect labelRect = GUILayoutUtility.GetLastRect();
            labelRect.x += 10;
            GUI.Label(labelRect, "Create new");
        
                
            if (GUILayout.Button(GUIContent.none, EditorStyles.toolbarButton))
            {
                Close();
                _onOpenDatabase?.Invoke();
            }
                
            labelRect = GUILayoutUtility.GetLastRect();
            labelRect.x += 10;
            GUI.Label(labelRect, "Open");
        }
    }
}