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
            Debug.Log($"StartCall: {callID}");

            OpenCallPanel(callID);
        }

        public void PickUpPhone(int callID)
        {
            Debug.Log($"PickUpPhone: {callID}");
            SetActivePanelState(isActive: false);
        }

        public void HangUpPhone(int callID)
        {
            Debug.Log($"HangUpPhone: {callID}");
            SetActivePanelState(isActive: false);
        }

        private void OpenCallPanel(int callID)
        {
            // TODO: Added validation callID

            SetActivePanelState(isActive: true);

            callPanel.callCharacter.sprite = characterDatas.First(character => character.ID == callID).Sprite;

            // callPanel.pickUpPhoneButton.onClick.AddListener(delegate { SetActivePanelState(true); });
            // callPanel.hangUpPhoneButton.onClick.AddListener(delegate { SetActivePanelState(false); });
        }

        private void CloseCallPanel(int callID)
        {
            // TODO: Added validation callID

            SetActivePanelState(isActive: false);

            // callPanel.pickUpPhoneButton.onClick.RemoveAllListeners();
            // callPanel.hangUpPhoneButton.onClick.RemoveAllListeners();
        }

        private void SetActivePanelState(bool isActive) =>
            callPanel.callPanel.gameObject.SetActive(isActive);
    }
}