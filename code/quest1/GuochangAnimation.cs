using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuochangAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool hasPlayed = false;
    public GameObject ani3;
    public Canvas canvas;
    public Sprite newSprite;

    void Start()
    {
        // 获取 Animator 组件
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //禁用组件
        if(ani3 != null) ani3.SetActive(false);
        if(canvas != null) canvas.gameObject.SetActive (false);
        // 开始播放动画
        animator.Play("guochang");
    }

    void Update()
    {
        if (!hasPlayed && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            // 动画已经播放完一次
            hasPlayed = true;
            // 禁用 Animator 组件
            animator.enabled = false;

            if(newSprite != null){

                spriteRenderer.sprite = newSprite;

            }
            

            //启用组件
            if(ani3 != null) ani3.SetActive (true );
            if(canvas != null) canvas.gameObject.SetActive (true);
        }
    }
}

