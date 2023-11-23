//点击电脑 进入对话

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using Unity.VisualScripting;

public class ComputerInteraction : MonoBehaviour
{
    // 你的对话名称或者对话ID
    public string conversationName = "Quest1Trigger";
    public bool oneTime = false;
    private void OnMouseDown()
    {
        // 在控制台输出，以确认点击事件是否被捕获
        // Debug.Log("Computer was clicked.");

        // 如果当前没有对话正在进行，则开始对话
        if (!DialogueManager.IsConversationActive && oneTime == false)
        {
            // 开始对话
            DialogueManager.StartConversation(conversationName);
            oneTime = true;
        }
    }
}

