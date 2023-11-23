//当玩家进入传送门区域时，传送门变为Noshow动画

using UnityEngine;

public class PortalController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("PortalController：已设置Animator组件。", this);
    }

    // 使用2D触发器事件
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("PortalController：OnTriggerEnter2D被调用，触发者：" + other.name, this);

        if (other.CompareTag("Player"))
        {
            Debug.Log("PortalController：玩家已进入传送门区域。", this);
            HidePortal();
        }
    }

    public void HidePortal()
    {
        Debug.Log("PortalController：尝试隐藏传送门。", this);
        animator.SetTrigger("NoShowTrigger");
    }
}
