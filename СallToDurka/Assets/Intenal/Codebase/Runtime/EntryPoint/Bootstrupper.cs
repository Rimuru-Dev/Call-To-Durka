using System.Collections.Generic;
using UnityEngine;
using YG;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class Bootstrupper : MonoBehaviour
    {
        [Header("Dependency's"), SerializeField]
        private YandexGame yandexSDK;

        [Header("Setting's"), SerializeField] private GeneralGameSettings generalGameSettings;
        [Header("Data's"), SerializeField] private List<CharacterData> characterDatas;

        [Header("View's"), SerializeField] private CallViewController callViewController;
        private CallController callController;

        private void Awake() =>
            callController = new CallController(callViewController, generalGameSettings, characterDatas);

        private void Start() =>
            callViewController.Initialize(callController);
    }
}