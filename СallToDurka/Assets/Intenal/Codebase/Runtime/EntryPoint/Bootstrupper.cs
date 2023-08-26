using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class Bootstrupper : MonoBehaviour
    {
        [Header("Setting's"), SerializeField] private GeneralGameSettings generalGameSettings;
        [Header("Data's"), SerializeField] private List<CharacterData> characterDatas;

        [FormerlySerializedAs("callPanelView")] [FormerlySerializedAs("callPanel")] [SerializeField] private MemeCallPanel memeCallPanel;
        [SerializeField] private CallController callController;

        private void Awake() =>
            callController.Init(memeCallPanel, generalGameSettings, characterDatas);
    }
}