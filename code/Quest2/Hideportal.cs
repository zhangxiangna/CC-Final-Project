using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideportal : MonoBehaviour

{
    public Animator portalAnimator; // 引用portal6的Animator

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.name == "player3")
        {
            Debug.Log("player3触发了portal6的触发器"); // 确认是player3触发了触发器
            portalAnimator.SetTrigger("Activate"); // 激活动画状态转换的触发器
        }
    }

    // 通过动画事件调用的方法
    public void DisablePortal()
    {
        Debug.Log("动画结束，即将禁用portal6"); // 确认动画事件被触发
        gameObject.SetActive(false); // 禁用portal6对象
    }


}