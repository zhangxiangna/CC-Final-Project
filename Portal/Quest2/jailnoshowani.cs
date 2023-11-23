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
