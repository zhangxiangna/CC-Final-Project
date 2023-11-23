using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemcontrol : MonoBehaviour
 {
    public GameObject studio4;
    public GameObject background;
    public GameObject eve2;
    public GameObject robot;

    public void ChangeSceneState() {
        // 禁用studio4
        if (studio4 != null) {
            studio4.SetActive(false);
        }

        // 启用background, eve2, 和 robot
        if (background != null) {
            background.SetActive(true);
        }
        if (eve2 != null) {
            eve2.SetActive(true);
        }
        if (robot != null) {
            robot.SetActive(true);
        }
    }
}
