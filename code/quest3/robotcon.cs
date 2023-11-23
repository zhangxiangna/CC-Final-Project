using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class robotcon : MonoBehaviour
{
    private bool hasTriggered = false;
    private void OnMouseDown()
    {
        // 假设'youngman1'是您在Dialogue System中设置的对话的名字
        if (!DialogueManager.IsConversationActive)
        {
            DialogueManager.StartConversation("robot", transform);
            hasTriggered = true;
        }
    }
}

