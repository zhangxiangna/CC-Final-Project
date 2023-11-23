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
