using UnityEngine;
using UnityEngine.Events;

namespace RimuruDev.YandexGame.ScriptsYG
{
    public class PromptYG : MonoBehaviour
    {
        [Header("Buttons serialize")]
        [Tooltip("������ (����������� ������ ��� �����), ������� ����� �������� � ���, ��� ����� �� ��������������. ������ ������ ����� �� ���������, �����, ���� ����� �� ����� �������������� - ������ �� ����� ������������.")]
        public GameObject notSupported;
        [Tooltip("������ (����������� ������ ��� �����), ������� ����� �������� � ���, ��� ����� ��� ����������. ������ ������ ����� �� ���������, �����, ���� ����� ��� ���������� - ������ �� ����� ������������.")]
        public GameObject done;
        [Tooltip("������ � �������, ������� ����� ���������� ���������� ����� �� ������� ���� (��������, �� ��������������). ��� ����� �� ������ ���������� ��������� ����� PromptShow ����� ������ ������ ��� ����� YandexGame ������.")]
        public GameObject showDialog;
        [Header("Events")]
        [Space(5)]
        public UnityEvent onPromptSuccess;
        public UnityEvent onPromptFail;

        private void Awake()
        {
            if (notSupported) notSupported.SetActive(false);
            if (done) done.SetActive(false);
            showDialog.SetActive(false);
        }

        private void OnEnable()
        {
            YandexGame.GetDataEvent += UpdateData;
            YandexGame.PromptSuccessEvent += OnPromptSuccess;
            YandexGame.PromptFailEvent += OnPromptFail;

            if (YandexGame.SDKEnabled) UpdateData();
        }
        private void OnDisable()
        {
            YandexGame.GetDataEvent -= UpdateData;
            YandexGame.PromptSuccessEvent -= OnPromptSuccess;
            YandexGame.PromptFailEvent -= OnPromptFail;
        }

        public void UpdateData()
        {
#if UNITY_EDITOR
            YandexGame.EnvironmentData.promptCanShow = true;
#endif
            if (YandexGame.savesData.promptDone)
            {
                if (notSupported) notSupported.SetActive(false);
                if (done) done.SetActive(true);
                showDialog.SetActive(false);
            }
            else if (!YandexGame.EnvironmentData.promptCanShow)
            {
                if (notSupported) notSupported.SetActive(true);
                if (done) done.SetActive(false);
                showDialog.SetActive(false);
            }
            else
            {
                if (notSupported) notSupported.SetActive(false);
                if (done) done.SetActive(false);
                showDialog.SetActive(true);
            }
        }

        public void PromptShow() => YandexGame.PromptShow();

        void OnPromptSuccess()
        {
            onPromptSuccess?.Invoke();
            UpdateData();
        }
        void OnPromptFail()
        {
            YandexGame.EnvironmentData.promptCanShow = false;
            onPromptFail?.Invoke();
            UpdateData();
        }
    }
}