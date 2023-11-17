# CC-Final-Project
Creative Computing 22f Final Project: Game Design: The Wheel of Time 

## Week 1（9/6-15/6）: Ideation and Conceptualization
During the week, I thought about the type of game and theme in my head. I would like to make an adventure fiction game. It's about time travel and non-linear narratives. This has been a hobby of mine for a long time. Also, because of my own aesthetic, I designed the game in a 2D horizontal pixel style.

## Week 2 (June 16 - June 22): Concept Finalization and Initial Meeting

I Finalize the game concept: a 2D pixel-styled visual novel game with time-travel elements and some ethical and moral reflections. As well as during the week, I investigated some related games and create a research document outlining your initial ideas and inspirations. Meet with my supervisor to discuss the project scope and objectives.
![image](https://github.com/zhangxiangna/CC-Final-Project/blob/main/IMG/1.png)
![image](https://github.com/zhangxiangna/CC-Final-Project/blob/main/IMG/2.png)

## Week3-Week6 (23/6/2023-20/7/2023) : Research

Play games similar to your concept, like Disco Elysium, Road 96. Read literature about non-linear narratives, like Arrivals, to understand their mechanics and storytelling. Record some of the elements that I find attractive to incorporate within my game.

## Week7-Week9(21/7/2023-10/8/2023): World Building and Story

Develop the game's world, including the setting, backstory and game plot. Create detailed profiles for main characters and NPCs. Write the initial drafts of the story scripts and dialogue.

I can't put it up in its entirety because the game plot document I wrote has over 10,000 words. If you're interested, you can click this link: (https://docs.google.com/document/d/1cVnI4G6P64Auf2cwGjgl5idk-e6_gdw5/edit?usp=drive_link&ouid=117307447688610825269&rtpof=true&sd=true)
![image](https://github.com/zhangxiangna/CC-Final-Project/blob/main/IMG/40.png)


## Week9-Week12(4/8/2023-31/8/2023)：Asset Design and Production

Design in-game assets: scenarios, player characters, NPCs, and animations. Develop the UI, focusing on user experience and aesthetic coherence. Begin creating initial animations and character designs.

### Characters Design:
![image](https://github.com/zhangxiangna/CC-Final-Project/blob/main/IMG/42.png)

### Scenes Design:
![image](https://github.com/zhangxiangna/CC-Final-Project/blob/main/IMG/scene1.jpg)
![image](https://github.com/zhangxiangna/CC-Final-Project/blob/main/IMG/jail-pixel.jpg)
![image](https://github.com/zhangxiangna/CC-Final-Project/blob/main/IMG/studio2-1.png)

## Week 13(1/9/2023-7/9-2023): Starting in UNITY

Set up the game project in Unity. Implement basic dialogue frames and character animations. Test initial animations and dialogue systems for functionality.

![image](https://github.com/zhangxiangna/CC-Final-Project/blob/main/IMG/6.png)
Player Animations:

```C#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim; 
    private Rigidbody2D rb; 

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetAnimation();
    }

    public void SetAnimation()
    {
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
    }
}
```
Player Movements:
```C#
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
```
![image](https://github.com/zhangxiangna/CC-Final-Project/blob/main/IMG/9.png)

## Week14 (8/9/2023-14/9/2023): Developing the first chapter

Creating the first chapter in unity, including character animation, scene switching, dialog introduction, and puzzle creation. One in particular I'd like to mention is the puzzle creation for a light-up game where I spent some time.
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/8d0a065d-d490-4df7-b6e5-856d7ac6908a)
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigg : MonoBehaviour
{
    public Animator portalAnimator; // 在 Inspector 中引用 Portal2 的 Animator
    public Animator playerAnimator;
    public Animator oldstudio2Animator;
    public GameObject oldstudio2; // oldstudio2 物体
    public GameObject portal2; // portal2 物体
    public GameObject studio2_1; // studio2-1 物体

    public GameObject q1end;


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Player2")
        {
            // 当 Player2 进入 Portal2 的 Collider 时，触发 NoShow 动画
            portalAnimator.SetTrigger("NoS");
            playerAnimator.SetTrigger("PlayerNoShow");

            StartCoroutine(TriggerOldstudio2Animation());

        }

    }

    IEnumerator TriggerOldstudio2Animation()
    {
        // 等待一秒
        yield return new WaitForSeconds(1f);

        // 触发 oldstudio2 的 NoShow 动画
        oldstudio2Animator.SetTrigger("NoShow");
    }

    public void OnAnimationEnd()
    {
        oldstudio2.SetActive(false); // 禁用 oldstudio2
        portal2.SetActive(false); // 禁用 portal2
        studio2_1.SetActive(true); // 启用 studio2-1
        q1end.SetActive (true);
    }
}
```

Here's the code for my light-up game design:
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private bool[,] grid = new bool[5, 5]; // 存储方格状态的二维数组
    public Sprite Bad;
    public Sprite Good;
    public bool isGameSuccessful = false;
    void Start()
    {
        InitializeGrid(); // 初始化网格状态
        UpdateGridVisuals(); // 更新网格的视觉表示
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                // 点击到了一个方格，提取其坐标
                string[] coordinates = hit.collider.gameObject.name.Split('.');
                int x = int.Parse(coordinates[0]) - 1;
                int y = int.Parse(coordinates[1]) - 1;

                ToggleSquare(x, y); // 处理点击逻辑
            }
        }
    }

    void InitializeGrid()
    {
        // 设置所有方格为亮起状态
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                grid[i, j] = true;
            }
        }

        // 设置特定方格为暗状态
        grid[0, 0] = grid[0, 1] = grid[0, 3] = grid[0, 4] = false;
        grid[2, 0] = grid[2, 1] = grid[2, 3] = grid[2, 4] = false;
        grid[3, 4] = false;
        grid[4, 0] = grid[4, 1] = false;
    }

    void ToggleSquare(int x, int y)
    {
        // 切换被点击方格的状态
        grid[x, y] = !grid[x, y];

        // 切换相邻方格的状态
        ToggleAdjacentSquares(x, y);

        // 更新网格的视觉表示
        UpdateGridVisuals();

        // 检查游戏是否获胜
        CheckForWin();
    }

    void ToggleAdjacentSquares(int x, int y)
    {
        // 切换上方格的状态（如果存在）
        if (x > 0) grid[x - 1, y] = !grid[x - 1, y];
        // 切换下方格的状态（如果存在）
        if (x < 4) grid[x + 1, y] = !grid[x + 1, y];
        // 切换左方格的状态（如果存在）
        if (y > 0) grid[x, y - 1] = !grid[x, y - 1];
        // 切换右方格的状态（如果存在）
        if (y < 4) grid[x, y + 1] = !grid[x, y + 1];
    }

    void UpdateGridVisuals()
    {
        // 遍历每个方格并根据grid数组的状态更新它们的视觉表示

        for(int x = 0; x < 5; x++){

            for(int y = 0; y < 5; y++){

                GameObject square = GameObject.Find(x + 1 + "." + (y + 1));
                if(square != null){

                    SpriteRenderer sr = square.GetComponent<SpriteRenderer>();
                    if(sr != null){

                        sr.sprite = grid[x, y] ? Bad : Good;
                    }
                }
            }
        }
    }

    void CheckForWin()
    {
        // 检查是否所有方格都亮起
        foreach (bool state in grid)
        {
            if (!state) return; // 如果发现一个暗的方格，提早结束函数
        }
        isGameSuccessful = true;
        Debug.Log("游戏胜利！"); // 如果所有方格都亮起，游戏胜利
    }
}
```
Puzzle Design:
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/f40d4e38-2037-4aac-b1ea-5d2c06da7d20)
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/2184d87c-f7fe-459c-98a8-84425a3fa734)

## Week15(15/9/2023-21/9/2023): Second Meeting

Second meeting with my supervisor We had an in-depth discussion about the content of the game and the development process in unity. Since I've only made it to the first chapter in unity and I wanted my supervisor to know all of my plots and playthroughs, I created a rough draft as one of the materials for the meeting.
![ab3a715f168e4190569639fe68974d4](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/7078f69b-676d-472b-bf33-c827510539a6)

Unfortunately, my supervisor told me that my game has too much content, and that I should minimize my workload by cutting out as many unnecessary episodes as possible. After discussing this, I cut my game down from eight chapters to three. (This decision has since been proven to be the right one.) (As well as this is why I've kept the images above small, as most of them have been put on hold for now.)

## Week16-17(22/9/2023-5/10/2023): Developing the Second chapter

Develop the second chapter, focusing on advancing the story and gameplay complexity. In this chapter, the main task of the Player is to return to the Middle Ages to rescue a young man. There are not many puzzles designed in this chapter, and the player needs to get information through dialogues to complete the reasoning. So the focus in this chapter is on animation and dialog design.
Dialogue:
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/4e13cc73-8fdc-4a67-b715-77fd2b923e23)
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/626f1f96-5e10-476e-8a77-53113b023475)
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/d6fcc84a-96b7-4665-9036-f4bf95cd4817)
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/b53f345a-ae6d-4cbe-8212-6de98b9ea0c5)
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/6814ed63-7e7a-4093-9536-8c83941bf6d3)
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/3329f192-00ba-4b6e-b58d-d144bf02c771)
Scenes:
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/0e105785-3e27-4f33-923c-a698a7f7486c)
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/4a0b94e3-0878-4e95-9051-d174f588dd66)
Code:
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Automove : MonoBehaviour
{
    public GameObject eve;
    private Animator eveAnimator;
    private float targetX = -2f;
    private float moveSpeed = 1f;

    void Start()
    {
        // 假设eve最初在x=-8的位置
        eve.transform.position = new Vector3(-8f, eve.transform.position.y, eve.transform.position.z);

        // 获取Animator组件
        eveAnimator = eve.GetComponent<Animator>();

        // 开始移动和动画
        StartCoroutine(MoveEve());
    }

    private IEnumerator MoveEve()
    {
        // 播放动画
        eveAnimator.SetBool("IsWalking", true);

        // 移动eve直到达到目标位置
        while(eve.transform.position.x < targetX)
        {
            eve.transform.position = new Vector3(eve.transform.position.x + moveSpeed * Time.deltaTime, eve.transform.position.y, eve.transform.position.z);
            yield return null;
        }

        // 停止动画
        eveAnimator.SetBool("IsWalking", false);

        yield return new WaitForSeconds(1f);

        // 触发对话
        StartDialogue();
    
    }

    private void StartDialogue()
    {
        DialogueManager.StartConversation("Q2Start");

}
}
```

## Week18-Week19(6/10/2023-19/10/2023): Developing the last chapter of the game

This is the last chapter of the game in which there are no puzzle designs. There are some choices involved and two different endings.
```C#
using UnityEngine;

public class PortalController2 : MonoBehaviour
{
    public Animator studioAnimator; // 确保在 Inspector 中引用了 Studio 的 Animator
    public Animator playerAnimator; // 确保在 Inspector 中引用了 Player 的 Animator

    // 动画事件调用这个方法
    public void OnPortalNoShowComplete()
    {
        // 触发Studio的NoShow动画
        if (studioAnimator != null)
        {
            studioAnimator.SetTrigger("StudioNoShow");
        }
        else
        {
            Debug.LogError("Studio animator is not assigned!", this);
        }

        // 触发Player的NoShow动画
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("PlayerNoShow");
        }
        else
        {
            Debug.LogError("Player animator is not assigned!", this);
        }
    }
}
```

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemcontrol : MonoBehaviour
 {
    public GameObject studio4;
    public GameObject background;
    public GameObject eve2;
    public GameObject robot;

    public void ChangeSceneState() {
        // 禁用studio4
        if (studio4 != null) {
            studio4.SetActive(false);
        }

        // 启用background, eve2, 和 robot
        if (background != null) {
            background.SetActive(true);
        }
        if (eve2 != null) {
            eve2.SetActive(true);
        }
        if (robot != null) {
            robot.SetActive(true);
        }
    }
}

```
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/9510eb73-e5da-4ea5-85dd-c0ebdc5a3852)
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/f17c5a28-18f2-4a8c-95b0-1547dc1b454c)
![image](https://github.com/zhangxiangna/CC-Final-Project/assets/115575320/6b6abd9c-6cfb-43bc-b8ef-e5a23c08db3e)

## Week20(20/10/2023-26/10/2023): Testing & Feedback

During the week, I invited five friends to give my game a try. They looked for bugs in my game and I made changes to the bugs and recorded their feedback on the game.

## Week21(27/10/2023-2/11/2023): Outlining

Begin outlining my essay. Focus on the introduction and background, detailing my inspiration and objectives for the game. Outline the structure and main points you plan to cover.

## Week 22 (3/11/2023-9/11/2023): Writing

Start writing the main part of the paper, which consists mainly of methodology, results, discussion and conclusions. Explain in detail how I made the game, what challenges I encountered, and how it turned out. why the results are like they are, what I have learned. And what could have gone better if I was to do it again.

## Week23(10/11/2023-16/11/2023): Revising
The essay, game, and all accompanying documentation were finalized.

## Week24(17/11/2023-23/11/2023): 

The essay, game, and all accompanying documentation were finalized.All materials were prepared for submission, adhering to the project's guidelines and requirements.A thorough double-check was conducted on all components for completeness and accuracy, ensuring readiness for submission.
