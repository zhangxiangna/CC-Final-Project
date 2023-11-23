using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigg : MonoBehaviour
{
    public Animator portalAnimator; // 在 Inspector 中引用 Portal2 的 Animator
    public Animator playerAnimator;
    public Animator oldstudio2Animator;
    public GameObject oldstudio2; // oldstudio2 物体
    public GameObject portal2; // portal2 物体
    public GameObject studio2_1; // studio2-1 物体

    public GameObject q1end;


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Player2")
        {
            // 当 Player2 进入 Portal2 的 Collider 时，触发 NoShow 动画
            portalAnimator.SetTrigger("NoS");
            playerAnimator.SetTrigger("PlayerNoShow");

            StartCoroutine(TriggerOldstudio2Animation());

        }

    }

    IEnumerator TriggerOldstudio2Animation()
    {
        // 等待一秒
        yield return new WaitForSeconds(1f);

        // 触发 oldstudio2 的 NoShow 动画
        oldstudio2Animator.SetTrigger("NoShow");
    }

    public void OnAnimationEnd()
    {
        oldstudio2.SetActive(false); // 禁用 oldstudio2
        portal2.SetActive(false); // 禁用 portal2
        studio2_1.SetActive(true); // 启用 studio2-1
        q1end.SetActive (true);
    }
}
