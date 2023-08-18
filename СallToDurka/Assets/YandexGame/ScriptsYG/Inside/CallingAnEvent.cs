#if UNITY_EDITOR
using System.Collections;
using UnityEngine;

namespace RimuruDev.YandexGame.ScriptsYG.Inside
{
    public class CallingAnEvent : MonoBehaviour
    {
        public IEnumerator CallingAd(float duration)
        {
            yield return new WaitForSecondsRealtime(duration);
            YandexGame.Instance.CloseFullAd();
            Destroy(gameObject);
        }

        public IEnumerator CallingAd(float duration, int id)
        {
            yield return new WaitForSecondsRealtime(duration);
            YandexGame.Instance.CloseVideo();
            YandexGame.Instance.RewardVideo(id);
            Destroy(gameObject);
        }
    }
}
#endif