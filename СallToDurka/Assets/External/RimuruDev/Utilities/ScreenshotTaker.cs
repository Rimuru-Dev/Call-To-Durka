// ReSharper disable CommentTypo

// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - Gists:    https://gist.github.com/RimuruDev/0f064261fe501dbfe894d0ec6c18ca67
// **************************************************************** //

#if UNITY_EDITOR
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Helpers
{
    /// <summary>
    /// Creating screenshots of Game screen for convenient work and creating promotional materials for YandexGames platform.
    /// </summary>
    [SelectionBase]
    [DisallowMultipleComponent]
    [HelpURL("https://gist.github.com/RimuruDev/0f064261fe501dbfe894d0ec6c18ca67")]
    public sealed class ScreenshotTaker : MonoBehaviour
    {
        [SerializeField] private string folderName = "Screenshots";

        [System.Diagnostics.Conditional("DEBUG")]
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
                CaptureScreenshot("ru");

            if (Input.GetKeyDown(KeyCode.F2))
                CaptureScreenshot("en");

            if (Input.GetKeyDown(KeyCode.F3))
                CaptureScreenshot("tr");
        }

        [ContextMenu("Take Screenshot")]
        [System.Diagnostics.Conditional("DEBUG")]
        private void CaptureScreenshot(string language)
        {
            var folderPath = Application.dataPath + "/" + folderName;

            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            var screenshotPath = folderPath + $"/{language}_screenshot_" +
                                 System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

            ScreenCapture.CaptureScreenshot(screenshotPath, 1);

            Debug.Log($"<color=magenta>Screenshot saved: {screenshotPath}</color>");
        }
    }
}
#endif