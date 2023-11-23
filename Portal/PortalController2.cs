using UnityEngine;

public class PortalController2 : MonoBehaviour
{
    public Animator studioAnimator; // 确保在 Inspector 中引用了 Studio 的 Animator
    public Animator playerAnimator; // 确保在 Inspector 中引用了 Player 的 Animator

    // 动画事件调用这个方法
    public void OnPortalNoShowComplete()
    {
        // 触发Studio的NoShow动画
        if (studioAnimator != null)
        {
            studioAnimator.SetTrigger("StudioNoShow");
        }
        else
        {
            Debug.LogError("Studio animator is not assigned!", this);
        }

        // 触发Player的NoShow动画
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("PlayerNoShow");
        }
        else
        {
            Debug.LogError("Player animator is not assigned!", this);
        }
    }
}

