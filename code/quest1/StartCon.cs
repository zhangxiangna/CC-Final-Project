using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Collections;

public class StartCon : MonoBehaviour
{
    public string conversationName = "afterscreen"; // 对话的名称

    void Start()
    {
        StartCoroutine(StartDialogueAfterDelay(2f)); // 延迟2秒后开始对话
    }

    IEnumerator StartDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DialogueManager.StartConversation(conversationName); // 开始对话
    }
}
