using UnityEngine;

public class PersistOnLoad : MonoBehaviour

{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
