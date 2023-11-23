//Quest1End场景中开始studio2-1是禁用的

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Studio21 : MonoBehaviour
{
    public GameObject studio2_1; // 在 Inspector 中引用 Studio2-1
    public GameObject q1end;

    void Start()
    {
        // 确保一开始 Studio2-1 是禁用和隐藏的
        studio2_1.SetActive(false);
        q1end.SetActive(false);
    }
}
