using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 引用 UI 命名空间

public class Backtostudio : MonoBehaviour
{
    public Button backButton; // 在 Inspector 中设置此引用

    void Start()
    {
        // 确保 backButton 已被指定
        if (backButton != null)
        {
            // 添加事件监听器
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }

    // 这个方法将在按钮被点击时调用
    void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Quest1end");
    }
}
