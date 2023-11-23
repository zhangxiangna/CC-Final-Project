using UnityEngine;
using PixelCrushers.DialogueSystem; // 引入Dialogue System的命名空间

public class TriggerDialogueOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        // 假设'youngman1'是您在Dialogue System中设置的对话的名字
        if (!DialogueManager.IsConversationActive)
        {
            DialogueManager.StartConversation("youngman1", transform);
        }
    }
}
