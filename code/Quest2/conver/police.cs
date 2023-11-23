using UnityEngine;
using PixelCrushers.DialogueSystem; // 引入Dialogue System的命名空间

public class police : MonoBehaviour

{
    private int clickCount = 0; // 用于跟踪点击次数

    private void OnMouseDown()
    {
        clickCount++; // 增加点击次数

        // 根据点击次数决定触发哪个对话
        if (clickCount == 1)
        {
            // 第一次点击时触发police1对话
            DialogueManager.StartConversation("police1", transform);
        }
        else
        {
            // 再次点击时触发police2对话
            DialogueManager.StartConversation("police2", transform);
        }
    }
}

