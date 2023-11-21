
## Overall
Camera

```C#
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
```

Mannagement
```C#

using UnityEngine;

public class PersistOnLoad : MonoBehaviour

{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

```

## Player
1.PlayerAnimations

```C#

//控制player的行走动画
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim; // 声明Animator组件的变量
    private Rigidbody2D rb; // 声明Rigidbody2D组件的变量

    private void Awake()
    {
        // 获取Animator和Rigidbody2D组件
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 每帧更新动画状态
        SetAnimation();
    }

    public void SetAnimation()
    {
        // 根据角色在x轴上的速度来设置动画参数
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
    }
}

```

2.Player Movements

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

## Portal

1.Portal Animation
```C#
//触发传送门的动画

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimationController : MonoBehaviour
{
    private Animator animator;
    public GameObject portal;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 调用这个方法来激活触发器并改变动画状态
    public void ShowPortal()
    {
        if(animator != null)
        {
            animator.SetTrigger("ShowTrigger");
        }
    }
}
//触发传送门的动画

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimationController : MonoBehaviour
{
    private Animator animator;
    public GameObject portal;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 调用这个方法来激活触发器并改变动画状态
    public void ShowPortal()
    {
        if(animator != null)
        {
            animator.SetTrigger("ShowTrigger");
        }
    }
}
```

```C#
//当玩家进入传送门区域时，传送门变为Noshow动画

using UnityEngine;

public class PortalController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("PortalController：已设置Animator组件。", this);
    }

    // 使用2D触发器事件
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("PortalController：OnTriggerEnter2D被调用，触发者：" + other.name, this);

        if (other.CompareTag("Player"))
        {
            Debug.Log("PortalController：玩家已进入传送门区域。", this);
            HidePortal();
        }
    }

    public void HidePortal()
    {
        Debug.Log("PortalController：尝试隐藏传送门。", this);
        animator.SetTrigger("NoShowTrigger");
    }
}
```
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

## QUEST1

animation
```C#
using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    public Animator animator; // Assign this in the inspector
    public string startTriggerName = "StartAnimation"; // Name of the trigger parameter to start the animation
    public string stopBoolName = "StopAnimation"; // Name of the bool parameter to stop the animation

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to trigger the animation after 5 seconds
        StartCoroutine(TriggerAnimationAfterDelay(5f));
    }

    private IEnumerator TriggerAnimationAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        
        // Trigger the animation to start
        animator.SetTrigger(startTriggerName);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click to stop the animation
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            // Set the bool parameter to true to stop the animation
            animator.SetBool(stopBoolName, true);
        }
    }
}
```

```C#
//Studio-oldStudio场景变化及动画

using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    // 在 Inspector 中分配的 Studio 的 Animator 组件引用
    public Animator studioAnimator;
    // 在 Inspector 中分配的 OldStudio GameObject 的引用
    public GameObject oldStudio;
    // 在 Inspector 中分配的 OldStudio 的 Animator 组件引用
    public Animator oldStudioAnimator;
    //引用Trigger gameobject
    public GameObject triggerObject;
    public GameObject Oldcomputer;

    // 在 Awake 中使 GameManager 在加载新场景时不被销毁
    //void Awake()
    //{
        // 防止 GameManager 在加载新场景时被销毁
    //    DontDestroyOnLoad(gameObject);
    //}

    void Start()
    {
        // 游戏开始时隐藏并禁用 OldStudio
        oldStudio.SetActive(false);
        triggerObject.SetActive(false);
        Oldcomputer.SetActive(false);
    }

    // 这个方法应该由 Studio 的 StudioNoShow 动画事件在最后一帧调用
    public void OnStudioNoShowComplete()
    {
        // 隐藏并禁用 Studio GameObject
        studioAnimator.gameObject.SetActive(false);

        // 显示 OldStudio GameObject 并播放 OldStudioShow 动画
        oldStudio.SetActive(true);
        oldStudioAnimator.SetTrigger("OldStudioShow");

        triggerObject.SetActive(true);
        Oldcomputer. SetActive(true);
    }
}
```

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 引用 UI 命名空间

public class Backtostudio : MonoBehaviour
{
    public Button backButton; // 在 Inspector 中设置此引用

    void Start()
    {
        // 确保 backButton 已被指定
        if (backButton != null)
        {
            // 添加事件监听器
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }

    // 这个方法将在按钮被点击时调用
    void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Quest1end");
    }
}
```

```C#
//过场动画，获得代码

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangetoAni : MonoBehaviour
{
    public Button invadeButton; // 按钮的引用
    private GridController gridController;
    void Start()
    {
        // 确保在Unity编辑器中已经设置了invadeButton的引用
        // 为按钮添加事件监听
        invadeButton.onClick.AddListener(OnInvadeButtonClicked);
        gridController = GameObject.Find("GameManager3").GetComponent<GridController>();
    }

    public void OnInvadeButtonClicked()
    {
        // 输出Debug信息
        Debug.Log("已点Invade");

        // 检查游戏是否成功，并可能转换场景
        LoadNextScene();
    }

    // 调用这个方法来转换场景
    public void LoadNextScene()
    {
        if (gridController.isGameSuccessful)
        {
            SceneManager.LoadScene("ScreenAni");
        }
        else
        {
            Debug.Log("游戏还未成功，不能跳转场景");
        }
    }
}

```

```C#
//点击电脑 进入对话

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using Unity.VisualScripting;

public class ComputerInteraction : MonoBehaviour
{
    // 你的对话名称或者对话ID
    public string conversationName = "Quest1Trigger";
    public bool oneTime = false;
    private void OnMouseDown()
    {
        // 在控制台输出，以确认点击事件是否被捕获
        // Debug.Log("Computer was clicked.");

        // 如果当前没有对话正在进行，则开始对话
        if (!DialogueManager.IsConversationActive && oneTime == false)
        {
            // 开始对话
            DialogueManager.StartConversation(conversationName);
            oneTime = true;
        }
    }
}

```

```C#
//摧毁防火墙游戏

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

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuochangAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool hasPlayed = false;
    public GameObject ani3;
    public Canvas canvas;
    public Sprite newSprite;

    void Start()
    {
        // 获取 Animator 组件
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //禁用组件
        if(ani3 != null) ani3.SetActive(false);
        if(canvas != null) canvas.gameObject.SetActive (false);
        // 开始播放动画
        animator.Play("guochang");
    }

    void Update()
    {
        if (!hasPlayed && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            // 动画已经播放完一次
            hasPlayed = true;
            // 禁用 Animator 组件
            animator.enabled = false;

            if(newSprite != null){

                spriteRenderer.sprite = newSprite;

            }
            

            //启用组件
            if(ani3 != null) ani3.SetActive (true );
            if(canvas != null) canvas.gameObject.SetActive (true);
        }
    }
}

```

```C#
//用户名输入正确，转到防火墙场景

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class InputMan : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button startButton;    // 确保在Unity编辑器中设置这个引用

    void Start()
    {
        //inputField = GameObject.Find("5TA-T5").GetComponent<InputField>();
        // 为按钮添加事件监听
        startButton.onClick.AddListener(OnStartButtonClicked);
        //inputField = GameObject.Find("5TA-T5").GetComponent<InputField>();
    }

    //void Update()
    //{
    //    OnStartButtonClicked();
    //}
    void OnStartButtonClicked()
    {
        if (inputField.text == "5TA-T5")
        {
            //Debug.Log("成功");
            SceneManager.LoadScene("OldComputerScreen2"); // 确保场景已在Build Settings中添加
        }

        else{
            //Debug.Log("失败");
        }
    }
}
```

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class OldComputerConversation : MonoBehaviour
{
    public string conversationName = "OldComputerConversation"; // 对话的名称
    public bool Onetime2 = false; //标记对话是否开始

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 确认触发者是 Player,且对话未发生过
        if (other.CompareTag("Player") && !Onetime2)
        {
            // 触发对话
            DialogueManager.StartConversation(conversationName);

            //标记对话已经开始，防止再次触发
            Onetime2 = true;
        }
    }
}
```

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

```C#
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
```

```C#
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
```

```C#
//Quest1End场景中开始studio2-1是禁用的

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Studio21 : MonoBehaviour
{
    public GameObject studio2_1; // 在 Inspector 中引用 Studio2-1
    public GameObject q1end;

    void Start()
    {
        // 确保一开始 Studio2-1 是禁用和隐藏的
        studio2_1.SetActive(false);
        q1end.SetActive(false);
    }
}
```

```C#
//点击oldcomputer，转至屏幕

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScreen : MonoBehaviour
{
    private void OnMouseDown()
    {
        // 场景名应与实际场景文件名一致
        SceneManager.LoadScene("OldComputerScreen");
    }
}
```
## QUEST2

```C#
using UnityEngine;

public class AnimationControl : MonoBehaviour

{
    public Animator studio3Animator; // 在Inspector中设置，用于控制studio3的动画
    public GameObject studio3;       // 在Inspector中设置，代表studio3对象
    public GameObject jail;          // 在Inspector中设置，代表jail对象
    public GameObject police;
    public GameObject eve;
    public GameObject portal5;

    // 由portal的q2noshow2动画的最后一帧动画事件调用
    public void TriggerStudio3Noshow2()
    {
        Debug.Log("11");
        studio3Animator.SetTrigger("StartNoshow2");
    }

    // 由studio3的noshow2动画的最后一帧动画事件调用
    public void HideStudio3AndEnableJail()
    {
        studio3.SetActive(false);
        jail.SetActive(true);
        police.SetActive(true);
        eve.SetActive(false);
        portal5.SetActive(false);
    }
}
```

```c3
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

```c#
using UnityEngine;

public class backstudio : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // 获取 Animator 组件
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查触发碰撞的对象是否是 player3
        if (other.gameObject.CompareTag("Player"))
        {
            // 改变动画状态
            animator.SetTrigger("StartNoshow");
        }
    }
}
```

```c#
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
```

```c#
using UnityEngine;

public class Door2 : MonoBehaviour
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
            jail.SetActive(true);
            police.SetActive(true);

            // 显示并启用twon对象
            twon.SetActive(false);
            oldman.SetActive(false);
            hatman.SetActive(false);
            bearded.SetActive(false );
        }
    }
}
```

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour

{
    
    public GameObject portal6;
    public void EnableGameObject()
    {
        portal6.SetActive(true);
    }
}
```

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidenshow : MonoBehaviour
{
    public GameObject hatman;
    public GameObject eve;
    public GameObject twon;
    public GameObject oldman;
    public GameObject bearded;
    public GameObject portal5;
    // Start is called before the first frame update
    void Start()
    {

        hatman.SetActive (false);
        eve.SetActive(false);
        twon.SetActive(false);
        oldman.SetActive(false);
        bearded.SetActive(false);
        portal5.SetActive(false);

        StartCoroutine(ShowObjectsAfterDelay(3.0f));

        IEnumerator ShowObjectsAfterDelay(float delay)
    {
        // 等待指定的延时
        yield return new WaitForSeconds(delay);

        // 显示对象
        portal5.SetActive(true);
        eve.SetActive(true);
    }
        
    }
}
```

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideportal : MonoBehaviour

{
    public Animator portalAnimator; // 引用portal6的Animator

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.name == "player3")
        {
            Debug.Log("player3触发了portal6的触发器"); // 确认是player3触发了触发器
            portalAnimator.SetTrigger("Activate"); // 激活动画状态转换的触发器
        }
    }

    // 通过动画事件调用的方法
    public void DisablePortal()
    {
        Debug.Log("动画结束，即将禁用portal6"); // 确认动画事件被触发
        gameObject.SetActive(false); // 禁用portal6对象
    }


}
```

```c#
using UnityEngine;

public class jailnoshowani : MonoBehaviour
{
    public Animator jailAnimator; // 在 Inspector 中设置，用于控制 jail 的动画
    public GameObject portal4;
    public GameObject jail;
    public GameObject Studio3;
    public GameObject police;

    // 这个方法将被动画事件调用
    public void StartJailNoshowAnimation()
    {
        jailAnimator.SetTrigger("StartNoshow");
    }

    public void DisablePortal4()
    {
        portal4.SetActive(false );
        jail.SetActive(false);
        police.SetActive(false);
        Studio3.SetActive (true);
    }
}
```

```c#
using UnityEngine;

public class portal4show : MonoBehaviour
{
    public GameObject portal4; // 在 Inspector 中设置

    public void ShowPortalObject()
    {
        if (portal4 != null)
        {
            portal4.SetActive(true);
        }
    }
}
```

