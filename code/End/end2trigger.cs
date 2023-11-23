using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class end2trigger : MonoBehaviour
{
    public string conversationTitle; // 对话的标题或标识符

    void Start()
    {
        Invoke("StartDialogue", 1f); // 1秒后触发对话
    }

    void StartDialogue()
    {
        DialogueManager.StartConversation(conversationTitle);
    }
}
