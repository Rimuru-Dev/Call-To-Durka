using System;
using System.Collections.Generic;
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
        }

        public void PickUpPhone(int callID)
        {
            Debug.Log($"PickUpPhone: {callID}");
        }

        public void HangUpPhone(int callID)
        {
            Debug.Log($"HangUpPhone: {callID}");
        }
    }
}