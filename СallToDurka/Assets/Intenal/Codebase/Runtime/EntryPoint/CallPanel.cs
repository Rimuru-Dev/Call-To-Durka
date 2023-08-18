using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class CallPanel : MonoBehaviour
    {
        [field: SerializeField] public Transform callPanel;
        [field: SerializeField] public Image callCharacter;
        [field: SerializeField] public Button pickUpPhoneButton;
        [field: SerializeField] public Button hangUpPhoneButton;
    }
}