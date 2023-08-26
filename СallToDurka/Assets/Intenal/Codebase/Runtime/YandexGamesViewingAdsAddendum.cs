using UnityEngine;

namespace RimuruDev.Intenal.Codebase.Runtime
{
    [SelectionBase]
    [DisallowMultipleComponent]
    //  [RequireComponent(typeof(ViewingAdsYG))]
    //  [RequireComponent(typeof(YandexGame.ScriptsYG.YandexGame))]
    public sealed class YandexGamesViewingAdsAddendum : MonoBehaviour
    {
        private const int On = 1, Off = 0;

        private void Start()
        {
        }

        private void OnDestroy()
        {
        }


        private void OnApplicationFocus(bool hasFocus) =>
            SetGlobalAudioVolume(!hasFocus);

        private void OnApplicationPause(bool isPaused) =>
            SetGlobalAudioVolume(isPaused);

        private static void SetGlobalAudioVolume(bool silence) =>
            AudioListener.volume = silence ? Off : On;
    }
}