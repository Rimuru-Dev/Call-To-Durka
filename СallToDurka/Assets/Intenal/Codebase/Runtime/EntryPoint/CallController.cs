using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [Serializable]
    public sealed class CallController
    {
        private readonly CallViewController callViewController;
        private readonly CallPanel callPanel;
        private readonly GeneralGameSettings generalGameSettings;
        private readonly List<CharacterData> characterDatas;

        public CallController(
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
            generalGameSettings.SourceAudio.Play(generalGameSettings.SourceAudioKey);
            generalGameSettings.SourceAudio.Loop = true;
        }

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
            callPanel.pickUpPhoneButton.gameObject.SetActive(true);
            callPanel.pickUpPhoneButton.onClick.RemoveAllListeners();

            YandexGame.ScriptsYG.YandexGame.FullscreenShow();

            SetActivePanelState(isActive: false);
        }

        private void SetActivePanelState(bool isActive) =>
            callPanel.callPanel.gameObject.SetActive(isActive);
    }
}