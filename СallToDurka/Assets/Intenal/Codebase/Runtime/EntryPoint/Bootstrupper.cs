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

        [Header("View's"), SerializeField] private CallViewController callViewController;
        [FormerlySerializedAs("callPanel")] [SerializeField] private CallPanelView callPanelView;
        [SerializeField] private CallController callController;

        private void Awake() =>
            callController.Init(callPanelView, generalGameSettings, characterDatas);

        private void Start() =>
            callViewController.Initialize(callController);
    }
}