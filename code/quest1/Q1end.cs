using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem; // 确保引入 Dialogue System 的命名空间
public class Q1end : MonoBehaviour

{
    void OnTriggerEnter2D(Collider2D collision) // 对于 2D 游戏，使用 OnTriggerEnter2D(Collider2D other)
    {
        if (collision.gameObject.name == "Player2")
        {
            Debug.Log("Player2 has collided with Q1end.");
            // 触发对话
            DialogueManager.StartConversation("Q1end");
        }
    }
}
