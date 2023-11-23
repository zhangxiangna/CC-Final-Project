//用户名输入正确，转到防火墙场景

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class InputMan : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button startButton;    // 确保在Unity编辑器中设置这个引用

    void Start()
    {
        //inputField = GameObject.Find("5TA-T5").GetComponent<InputField>();
        // 为按钮添加事件监听
        startButton.onClick.AddListener(OnStartButtonClicked);
        //inputField = GameObject.Find("5TA-T5").GetComponent<InputField>();
    }

    //void Update()
    //{
    //    OnStartButtonClicked();
    //}
    void OnStartButtonClicked()
    {
        if (inputField.text == "5TA-T5")
        {
            //Debug.Log("成功");
            SceneManager.LoadScene("OldComputerScreen2"); // 确保场景已在Build Settings中添加
        }

        else{
            //Debug.Log("失败");
        }
    }
}
