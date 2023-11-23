using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Automove : MonoBehaviour
{
    public GameObject eve;
    private Animator eveAnimator;
    private float targetX = -2f;
    private float moveSpeed = 1f;

    void Start()
    {
        // 假设eve最初在x=-8的位置
        eve.transform.position = new Vector3(-8f, eve.transform.position.y, eve.transform.position.z);

        // 获取Animator组件
        eveAnimator = eve.GetComponent<Animator>();

        // 开始移动和动画
        StartCoroutine(MoveEve());
    }

    private IEnumerator MoveEve()
    {
        // 播放动画
        eveAnimator.SetBool("IsWalking", true);

        // 移动eve直到达到目标位置
        while(eve.transform.position.x < targetX)
        {
            eve.transform.position = new Vector3(eve.transform.position.x + moveSpeed * Time.deltaTime, eve.transform.position.y, eve.transform.position.z);
            yield return null;
        }

        // 停止动画
        eveAnimator.SetBool("IsWalking", false);

        yield return new WaitForSeconds(1f);

        // 触发对话
        StartDialogue();
    
    }

    private void StartDialogue()
    {
        DialogueManager.StartConversation("Q2Start");

}
}
