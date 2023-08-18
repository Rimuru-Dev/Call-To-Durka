using UnityEditor;
using UnityEngine;

namespace RimuruDev.YandexGame.ScriptsYG.Inside
{
    public class ConfigYG : MonoBehaviour
    {
#if UNITY_EDITOR
        public static string patchYGPrefab = "Assets/YandexGame/Prefabs/YandexGame.prefab";

        public static InfoYG GetInfoYG()
        {
            GameObject ygPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(patchYGPrefab, typeof(GameObject));
            if (ygPrefab == null)
            {
                Debug.LogError($"������ YandexGame �� ��� ������ �� ����: {patchYGPrefab}");
                return null;
            }

            YandexGame ygScr = ygPrefab.GetComponent<YandexGame>();
            if (ygScr == null)
            {
                Debug.LogError($"�� ������� YandexGame �� ��� ������ ��������� YandexGame! ������ ������� ���������� �� ����: {patchYGPrefab}");
                return null;
            }

            InfoYG infoYG = ygScr.infoYG;
            if (ygScr == null)
            {
                Debug.LogError($"�� ���������� YandexGame �� ���������� ���� InfoYG! ������ YandexGame ���������� �� ����: {patchYGPrefab}");
                return null;
            }

            return infoYG;
        }
#endif
    }
}