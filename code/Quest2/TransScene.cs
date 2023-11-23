using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransScene : MonoBehaviour

 {
    void Update() {
        // 检测C键是否被按下
        if (Input.GetKeyDown(KeyCode.C)) {
            // 加载指定的场景
            SceneManager.LoadScene("future2");
        }
    }
}
