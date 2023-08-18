using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using UnityEditor;
using UnityEngine;
using AudioConfiguration = Plugins.Audio.Core.AudioConfiguration;

namespace Plugins.Audio.Editor
{
    [CustomPropertyDrawer(typeof(AudioDataProperty))]
    public class AudioDataPropertyDrawer : PropertyDrawer
    {
        private AudioConfiguration _audioConfiguration;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty idProperty = property.FindPropertyRelative("_id");
            SerializedProperty keyProperty = property.FindPropertyRelative("_key");
        
            if (_audioConfiguration == null)
            {
                _audioConfiguration = AudioConfiguration.GetInstance();
            }

            Rect labelRect = position;
            labelRect.width = EditorGUIUtility.labelWidth;
            labelRect.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.LabelField(labelRect, label);
            
            Rect popupRect = position;
            popupRect.height = EditorGUIUtility.singleLineHeight;
            popupRect.width = position.width - labelRect.width;
            popupRect.x += labelRect.width;
            
            if (GUI.Button(popupRect, keyProperty.stringValue, EditorStyles.popup))
            {
                Vector2 point = Vector2.zero;

                SelectAudioDataWindow.Open(SetProperties, point);
            }
                
            Rect foldoutRect = position;
            foldoutRect.height = EditorGUIUtility.singleLineHeight;
            
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, GUIContent.none);

            if (property.isExpanded)
            {
                GUI.enabled = false;

                Rect keyRect = foldoutRect;
                keyRect.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(keyRect, keyProperty);

                Rect idRect = keyRect;
                idRect.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(idRect, idProperty);

                GUI.enabled = true;
            }

            void SetProperties(AudioData data)
            {
                property.serializedObject.Update();
                
                idProperty.stringValue = data == null ? "Null" : data.ID;
                keyProperty.stringValue = data == null ? "None" : data.Key;

                property.serializedObject.ApplyModifiedProperties();
            }
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.isExpanded)
            {
                return EditorGUIUtility.singleLineHeight * 4;
            }
        
            return EditorGUIUtility.singleLineHeight;
        }
    }
}