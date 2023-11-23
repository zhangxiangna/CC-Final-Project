using UnityEngine;
using UnityEngine.SceneManagement;

public class Management : MonoBehaviour
{
    public string sceneToLoad = "Quest2-1"; // 在 Inspector 中设置要加载的场景名

    void Update()
    {
        // 检测鼠标右键点击（鼠标右键为 1）
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Quest2-1");
        }
    }
}

