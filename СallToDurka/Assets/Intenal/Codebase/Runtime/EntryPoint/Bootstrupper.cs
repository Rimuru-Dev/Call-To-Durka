using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class Bootstrupper : MonoBehaviour
    {
        [Header("Dependency's"), SerializeField]
        private YandexGame.ScriptsYG.YandexGame yandexSDK;

        [Header("Setting's"), SerializeField] private GeneralGameSettings generalGameSettings;
        [Header("Data's"), SerializeField] private List<CharacterData> characterDatas;

        [Header("View's"), SerializeField] private CallViewController callViewController;
        [SerializeField] private CallPanel callPanel;
        private CallController callController;

        private void Awake() =>
            callController = new CallController(callViewController, callPanel,generalGameSettings, characterDatas);

        private void Start() =>
            callViewController.Initialize(callController);
    }
}