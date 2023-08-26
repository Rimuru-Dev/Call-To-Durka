// ReSharper disable CommentTypo
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub:   https://github.com/RimuruDev
// **************************************************************** //

using UnityEngine;
using System.Collections.Generic;
using RimuruDev.Intenal.Codebase.Runtime.Data;
using RimuruDev.Intenal.Codebase.Runtime.View;
using RimuruDev.Intenal.Codebase.Runtime.Controller;

namespace RimuruDev.Intenal.Codebase.Runtime.Boot
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class Bootstrupper : MonoBehaviour
    {
        [SerializeField] private MemeCallPanel memeCallPanel;
        [SerializeField] private CallController callController;
        [SerializeField] private SourceAudioList sourceAudioList;
        [Space] [SerializeField] private MainRingtone mainRingtone;
        [SerializeField] private List<CharacterData> characterDatas;

        private void Awake() =>
            callController.Init(memeCallPanel, mainRingtone, characterDatas, sourceAudioList);
    }
}