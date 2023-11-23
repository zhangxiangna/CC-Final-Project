//过场动画，获得代码

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangetoAni : MonoBehaviour
{
    public Button invadeButton; // 按钮的引用
    private GridController gridController;
    void Start()
    {
        // 确保在Unity编辑器中已经设置了invadeButton的引用
        // 为按钮添加事件监听
        invadeButton.onClick.AddListener(OnInvadeButtonClicked);
        gridController = GameObject.Find("GameManager3").GetComponent<GridController>();
    }

    public void OnInvadeButtonClicked()
    {
        // 输出Debug信息
        Debug.Log("已点Invade");

        // 检查游戏是否成功，并可能转换场景
        LoadNextScene();
    }

    // 调用这个方法来转换场景
    public void LoadNextScene()
    {
        if (gridController.isGameSuccessful)
        {
            SceneManager.LoadScene("ScreenAni");
        }
        else
        {
            Debug.Log("游戏还未成功，不能跳转场景");
        }
    }
}

