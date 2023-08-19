using System;
using System.Collections.Generic;
using System.Linq;
using RimuruDev.Plugins.Audio.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    public sealed class CallController : MonoBehaviour
    {
        private  CallViewController callViewController;
        private  CallPanel callPanel;
        private  GeneralGameSettings generalGameSettings;
        private  List<CharacterData> characterDatas;

        public void Init(
            CallViewController callViewController,
            CallPanel callPanel,
            GeneralGameSettings generalGameSettings,
            List<CharacterData> characterDatas)
        {
            this.callViewController = callViewController;
            this.callPanel = callPanel;
            this.generalGameSettings = generalGameSettings;
            this.characterDatas = characterDatas;
        }

        public void StartCall(int callID)
        {
            // Debug.Log($"StartCall: {callID}");

            OpenCallPanel(callID);
        }

        public void PickUpPhone()
        {
            //   Debug.Log($"PickUpPhone:");

            // Audio
            {
                generalGameSettings.SourceAudio.Loop = false;
                generalGameSettings.SourceAudio.Stop();

                var character = characterDatas.First(character => character.ID == currentCharacter);
                character.AudioClip.Play(character.AudioClipKey);
                character.AudioClip.Loop = true;
            }

            callPanel.pickUpPhoneButton.gameObject.SetActive(false);
        }

        public void HangUpPhone()
        {
            generalGameSettings.SourceAudio.Stop();
            generalGameSettings.SourceAudio.Loop = false;

            CloseCallPanel();
        }

        private int currentCharacter = -1;

        private void OpenCallPanel(int callID)
        {
            currentCharacter = callID;

            SetActivePanelState(isActive: true);

            callPanel.callCharacter.sprite = characterDatas.First(character => character.ID == currentCharacter).Sprite;
            callPanel.characterName.text = characterDatas.First(character => character.ID == currentCharacter).Name;
            generalGameSettings.SourceAudio.Play(generalGameSettings.SourceAudioKey);
            generalGameSettings.SourceAudio.Loop = true;
        }
#if UNITY_EDITOR
        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate()
        {
            sourceAudios = new List<SourceAudio>();
            audioSources = new List<AudioSource>();

            foreach (var sourceAudio in UnityEngine.Object.FindObjectsOfType<SourceAudio>())
                sourceAudios.Add(sourceAudio);

            foreach (var audioSource in UnityEngine.Object.FindObjectsOfType<AudioSource>())
                audioSources.Add(audioSource);
        }
#endif

        [SerializeField] private List<SourceAudio> sourceAudios;
        [SerializeField] private List<AudioSource> audioSources;

        private void CloseCallPanel()
        {
            // Audio
            {
                var character = characterDatas.First(character => character.ID == currentCharacter);
                character.AudioClip.Stop();
                character.AudioClip.Loop = false;

                generalGameSettings.SourceAudio.Stop();
                generalGameSettings.SourceAudio.Loop = false;
                generalGameSettings.SourceAudio.Stop();
            }

            foreach (var sourceAudio in sourceAudios.Where(x => x != null))
            {
                sourceAudio.Stop();
                sourceAudio.Loop = false;
            }

            foreach (var audioSource in audioSources.Where(x => x != null))
            {
                audioSource.Stop();
                audioSource.loop = false;
            }

            callPanel.pickUpPhoneButton.gameObject.SetActive(true);
            callPanel.pickUpPhoneButton.onClick.RemoveAllListeners();

            YandexGame.ScriptsYG.YandexGame.FullscreenShow();

            SetActivePanelState(isActive: false);
        }

        private void SetActivePanelState(bool isActive) =>
            callPanel.callPanel.gameObject.SetActive(isActive);
    }
}