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
