using UnityEngine;
using UnityEngine.SceneManagement;

public class Toend1 : MonoBehaviour {
    void Update() {
        // 检测C键是否被按下
        if (Input.GetKeyDown(KeyCode.C)) {
            // 加载指定的场景
            SceneManager.LoadScene("end1-robot");
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            // 加载指定的场景
            SceneManager.LoadScene("end2-human");
        }
    }
}
