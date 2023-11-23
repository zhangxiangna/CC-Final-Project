using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class OldComputerConversation : MonoBehaviour
{
    public string conversationName = "OldComputerConversation"; // 对话的名称
    public bool Onetime2 = false; //标记对话是否开始

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 确认触发者是 Player,且对话未发生过
        if (other.CompareTag("Player") && !Onetime2)
        {
            // 触发对话
            DialogueManager.StartConversation(conversationName);

            //标记对话已经开始，防止再次触发
            Onetime2 = true;
        }
    }
}
