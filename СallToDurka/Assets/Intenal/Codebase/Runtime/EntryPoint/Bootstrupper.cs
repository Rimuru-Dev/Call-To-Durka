
// TODO: Избавиться от магических числе и делегировать подписку отписку в другой класс.

using System;
using System.Collections.Generic;
using UnityEngine;
using static RimuruDev.YandexGame.ScriptsYG.YandexGame;

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
        [SerializeField] private CallController callController;

        private void Awake() =>
            callController.Init(callPanel, generalGameSettings, characterDatas);

        private void Start() =>
            callViewController.Initialize(callController);

        private void OnEnable()
        {
            OpenFullAdEvent += OpenFullScreenAdv;
            CloseFullAdEvent += CloseFullScreenAdv;

            OpenVideoEvent += OpenVideoAdv;
            CloseVideoEvent += CloseVideoAdv;
        }

        private void OnDisable()
        {
            OpenFullAdEvent -= OpenFullScreenAdv;
            CloseFullAdEvent -= CloseFullScreenAdv;

            OpenVideoEvent -= OpenVideoAdv;
            CloseVideoEvent -= CloseVideoAdv;
        }

        private void OnDestroy()
        {
            OpenFullAdEvent -= OpenFullScreenAdv;
            CloseFullAdEvent -= CloseFullScreenAdv;

            OpenVideoEvent -= OpenVideoAdv;
            CloseVideoEvent -= CloseVideoAdv;
        }

        private void OpenFullScreenAdv() =>
            SetActiveForAD(0);

        private void CloseFullScreenAdv() =>
            SetActiveForAD(1);

        private void OpenVideoAdv() =>
            SetActiveForAD(0);

        private void CloseVideoAdv() =>
            SetActiveForAD(1);

        private void SetActiveForAD(int value)
        {
            AudioListener.volume = value;
            Time.timeScale = value;
        }
    }
}