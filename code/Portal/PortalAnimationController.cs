//触发传送门的动画

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimationController : MonoBehaviour
{
    private Animator animator;
    public GameObject portal;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 调用这个方法来激活触发器并改变动画状态
    public void ShowPortal()
    {
        if(animator != null)
        {
            animator.SetTrigger("ShowTrigger");
        }
    }
}
