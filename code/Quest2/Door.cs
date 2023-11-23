using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour

{
    public GameObject jail;  // 在Inspector中设置，代表jail对象
    public GameObject twon;  // 在Inspector中设置，代表twon对象
    public GameObject oldman;  // 在Inspector中设置，代表twon对象
    public GameObject bearded;  // 在Inspector中设置，代表twon对象
    public GameObject hatman;  // 在Inspector中设置，代表twon对象

    public GameObject police;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查触发碰撞的对象是否是玩家
        if (other.CompareTag("Player"))
        {
            // 禁用jail对象
            jail.SetActive(false);
            police.SetActive(false);

            // 显示并启用twon对象
            twon.SetActive(true);
            oldman.SetActive(true);
            hatman.SetActive(true);
            bearded.SetActive(true);
        }
    }
}
