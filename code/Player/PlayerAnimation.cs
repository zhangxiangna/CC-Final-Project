//控制player的行走动画
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim; // 声明Animator组件的变量
    private Rigidbody2D rb; // 声明Rigidbody2D组件的变量

    private void Awake()
    {
        // 获取Animator和Rigidbody2D组件
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 每帧更新动画状态
        SetAnimation();
    }

    public void SetAnimation()
    {
        // 根据角色在x轴上的速度来设置动画参数
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
    }
}
