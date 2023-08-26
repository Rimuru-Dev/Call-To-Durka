// ReSharper disable CommentTypo
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub:   https://github.com/RimuruDev
// **************************************************************** //

using YG;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using RimuruDev.Intenal.Codebase.Runtime.Data;
using RimuruDev.Intenal.Codebase.Runtime.View;

namespace RimuruDev.Intenal.Codebase.Runtime.Controller
{
    public sealed class CallController : MonoBehaviour
    {
        private MainRingtone mainRingtone;
        private MemeCallPanel memeCallPanel;
        private List<CharacterData> characterDatas;
        private int currentCharacter = -1;
        private SourceAudioList sourceAudioList;

        public void Init(
            MemeCallPanel callPanel,
            MainRingtone ringtone,
            List<CharacterData> characters, SourceAudioList sourcesAudioList)
        {
            memeCallPanel = callPanel;
            mainRingtone = ringtone;
            characterDatas = characters;
            sourceAudioList = sourcesAudioList;
        }

        private void Start()
        {
            for (var i = 0; i < memeCallPanel.memeCallButtons.Length; i++)
            {
                var id = i;
                memeCallPanel.memeCallButtons[id].onClick.AddListener(() => { StartCall(id); });
            }

            memeCallPanel.pickUpPhoneButton.onClick.AddListener(PickUpPhone);
            memeCallPanel.hangUpPhoneButton.onClick.AddListener(HangUpPhone);
        }

        private void OnDestroy()
        {
            foreach (var callButton in memeCallPanel.memeCallButtons)
                callButton.onClick.RemoveAllListeners();

            memeCallPanel.pickUpPhoneButton.onClick.RemoveListener(PickUpPhone);
            memeCallPanel.hangUpPhoneButton.onClick.RemoveListener(HangUpPhone);
        }

        private void StartCall(int callID) =>
            OpenCallPanel(callID);

        private void PickUpPhone()
        {
            mainRingtone.SourceAudio.Stop();
            
            var character = characterDatas.First(character => character.ID == currentCharacter);
            character.AudioClip.Play(character.AudioClipKey);
            character.AudioClip.Loop = true;

            memeCallPanel.pickUpPhoneButton.gameObject.SetActive(false);
        }

        private void HangUpPhone()
        {
            StopAllAudioSources();

            CloseCallPanel();
        }

        private void OpenCallPanel(int callID)
        {
            SetActivePanelState(isActive: true);

            currentCharacter = callID;

            memeCallPanel.callCharacter.sprite =
                characterDatas.First(character => character.ID == currentCharacter).Sprite;
            memeCallPanel.characterName.text = characterDatas.First(character => character.ID == currentCharacter).Name;

            mainRingtone.SourceAudio.Play(mainRingtone.SourceAudioKey);
            mainRingtone.SourceAudio.Loop = true;
        }

        private void CloseCallPanel()
        {
            memeCallPanel.pickUpPhoneButton.gameObject.SetActive(true);

            StopAllAudioSources();

            YandexGame.FullscreenShow();

            SetActivePanelState(isActive: false);
        }

        private void SetActivePanelState(bool isActive) =>
            memeCallPanel.callPanel.gameObject.SetActive(isActive);

        private void StopAllAudioSources()
        {
            foreach (var sourceAudio in sourceAudioList.SourceAudios)
                sourceAudio.Stop();
        }
    }
}