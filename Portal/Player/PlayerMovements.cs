//键盘ad键控制左右移动和人物翻转

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
public Rigidbody2D rb;
public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float faceDir = (float)transform.localScale.x;
        if(horizontalMove!=0)
        {
            rb.velocity = new Vector2(horizontalMove * speed * Time.deltaTime, rb. velocity.y);      
                    
            if(horizontalMove > 0){
            faceDir = 1.6f;//1.6是当前GameObject.transform.scale.x
            }
            if(horizontalMove < 0){
            faceDir = -1.6f;
            }     
            transform.localScale = new Vector3(faceDir,1.6f,1.6f); 
        }
    }
}
