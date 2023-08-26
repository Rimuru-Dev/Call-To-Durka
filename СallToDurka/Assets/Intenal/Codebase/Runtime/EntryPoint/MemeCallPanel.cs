using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class MemeCallPanel : MonoBehaviour
    {
        [field: SerializeField] public Transform callPanel;
        [field: SerializeField] public TextMeshProUGUI characterName;
        [field: SerializeField] public Image callCharacter;
        [field: SerializeField] public Button pickUpPhoneButton;
        [field: SerializeField] public Button[] memeCallButtons;
    }
}