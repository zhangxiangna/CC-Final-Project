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
