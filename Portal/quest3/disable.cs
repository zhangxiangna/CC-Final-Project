using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable : MonoBehaviour
{
    public GameObject background; // 背景对象的引用
    public GameObject robot; // 机器人对象的引用
    public GameObject eve2;

    void Start()
    {
        // 直接禁用背景对象
        background.SetActive(false);

        // 直接禁用机器人对象
        robot.SetActive(false);

        eve2.SetActive(false);
    }
}

