//相机跟随player移动

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private Vector3 distance; // 正确声明distance变量作为类的成员

    // Start is called before the first frame update
    void Start()
    {
        // 计算并存储摄像机与玩家之间的初始距离
        distance = transform.position - player.position;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // 在LateUpdate中更新摄像机的位置，保持与玩家的距离
        transform.position = player.position + distance;
    }
}

        
    
