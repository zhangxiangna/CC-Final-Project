using UnityEngine;
using System.Collections;

public class screenani : MonoBehaviour

{
    public Animator animator; // 在Unity编辑器中分配Animator组件

    // Start is called before the first frame update
    void Start()
    {
        // 开始协程，在游戏开始后3秒钟触发动画
        StartCoroutine(TriggerAnimationAfterDelay(3f));
    }

    private IEnumerator TriggerAnimationAfterDelay(float delay)
    {
        // 等待指定的延迟时间
        yield return new WaitForSeconds(delay);

        // 触发名为 "ActivateShanshuo" 的触发器，用于启动 "shanshuo" 动画状态
        animator.SetTrigger("ActivateShanshuo");
    }
}
