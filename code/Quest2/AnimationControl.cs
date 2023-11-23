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
