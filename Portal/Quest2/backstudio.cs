using UnityEngine;

public class backstudio : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // 获取 Animator 组件
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查触发碰撞的对象是否是 player3
        if (other.gameObject.CompareTag("Player"))
        {
            // 改变动画状态
            animator.SetTrigger("StartNoshow");
        }
    }
}
