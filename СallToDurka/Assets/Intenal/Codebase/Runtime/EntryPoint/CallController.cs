// TODO: Избавиться от MonoBehaviour, разделить класс.

using System;
using System.Collections.Generic;
using System.Linq;
using RimuruDev.Plugins.Audio.Core;
using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    public sealed class CallController : MonoBehaviour
    {
        private MemeCallPanel _memeCallPanel;
        private GeneralGameSettings generalGameSettings;
        private List<CharacterData> characterDatas;
        private int currentCharacter = -1;
        public GameObject audioComponent;

        public void Init(
            MemeCallPanel memeCallPanel,
            GeneralGameSettings generalGameSettings,
            List<CharacterData> characterDatas)
        {
            this._memeCallPanel = memeCallPanel;
            this.generalGameSettings = generalGameSettings;
            this.characterDatas = characterDatas;
        }

        private void Start()
        {
            for (var i = 0; i < _memeCallPanel.memeCallButtons.Length; i++)
            {
                var id = i;
                _memeCallPanel.memeCallButtons[i].onClick.AddListener(() => { StartCall(id); });
            }
        }

        private void OnDestroy()
        {
            foreach (var callButton in _memeCallPanel.memeCallButtons)
                callButton.onClick.RemoveAllListeners();
        }

        public void StartCall(int callID) =>
            OpenCallPanel(callID);

        public void PickUpPhone()
        {
            generalGameSettings.SourceAudio.Loop = false;
            generalGameSettings.SourceAudio.Stop();

            var character = characterDatas.First(character => character.ID == currentCharacter);
            character.AudioClip.Play(character.AudioClipKey);
            character.AudioClip.Loop = true;

            _memeCallPanel.pickUpPhoneButton.gameObject.SetActive(false);
        }

        public void HangUpPhone()
        {
            StopAllAudioSources();

            CloseCallPanel();
        }

        private void OpenCallPanel(int callID)
        {
            SetActivePanelState(isActive: true);

            currentCharacter = callID;

            _memeCallPanel.callCharacter.sprite =
                characterDatas.First(character => character.ID == currentCharacter).Sprite;
            _memeCallPanel.characterName.text =
                characterDatas.First(character => character.ID == currentCharacter).Name;

            generalGameSettings.SourceAudio.Play(generalGameSettings.SourceAudioKey);
            generalGameSettings.SourceAudio.Loop = true;
        }

        private void CloseCallPanel()
        {
            var character = characterDatas.First(character => character.ID == currentCharacter);
            character.AudioClip.Stop();
            character.AudioClip.Loop = false;

            generalGameSettings.SourceAudio.Stop();
            generalGameSettings.SourceAudio.Loop = false;

            _memeCallPanel.pickUpPhoneButton.gameObject.SetActive(true);
            _memeCallPanel.pickUpPhoneButton.onClick.RemoveAllListeners();

            StopAllAudioSources();

            audioComponent.SetActive(true);

            YandexGame.ScriptsYG.YandexGame.FullscreenShow();

            SetActivePanelState(isActive: false);
        }

        private void SetActivePanelState(bool isActive) =>
            _memeCallPanel.callPanel.gameObject.SetActive(isActive);

        private void StopAllAudioSources()
        {
            foreach (var audioSource in FindObjectsOfType<AudioSource>(true))
                audioSource.Stop();

            foreach (var sourceAudio in FindObjectsOfType<SourceAudio>(true))
                sourceAudio.Stop();

            audioComponent.SetActive(false);
        }
    }
}