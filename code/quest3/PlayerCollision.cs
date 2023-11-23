using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    public Animator portalAnimator; // 引用portal7的Animator

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "player4") {
            Debug.Log("player4触发了portal7的触发器"); // 确认是player4触发了触发器
            portalAnimator.SetTrigger("Activate2"); // 激活动画状态转换的触发器
        }
    }

    // 通过动画事件调用的方法
    public void DisablePortal() {
        Debug.Log("动画结束，即将禁用portal7"); // 确认动画事件被触发
        portalAnimator.gameObject.SetActive(false); // 禁用portal7对象
    }
}
