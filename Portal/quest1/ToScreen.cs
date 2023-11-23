//点击oldcomputer，转至屏幕

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScreen : MonoBehaviour
{
    private void OnMouseDown()
    {
        // 场景名应与实际场景文件名一致
        SceneManager.LoadScene("OldComputerScreen");
    }
}
