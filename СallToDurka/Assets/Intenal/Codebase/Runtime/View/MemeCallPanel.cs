// ReSharper disable CommentTypo
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub:   https://github.com/RimuruDev
// **************************************************************** //

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.Intenal.Codebase.Runtime.View
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class MemeCallPanel : MonoBehaviour
    {
        [field: SerializeField] public Transform callPanel;
        [field: SerializeField] public TextMeshProUGUI characterName;
        [field: SerializeField] public Image callCharacter;
        [field: SerializeField] public Button pickUpPhoneButton;
        [field: SerializeField] public Button hangUpPhoneButton;
        [field: SerializeField] public Button[] memeCallButtons;
    }
}