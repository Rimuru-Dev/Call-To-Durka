using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class CallPanelView : MonoBehaviour
    {
        [Header("Call Panel")]
        [field: SerializeField] public Transform callPanel;
        [field: SerializeField] public TextMeshProUGUI characterName;
        [field: SerializeField] public Image callCharacter;
        [field: SerializeField] public Button pickUpPhoneButton;

        [Header("Call Buttons")] 
        [field: SerializeField] public Button[] CallButtons;
    }
}