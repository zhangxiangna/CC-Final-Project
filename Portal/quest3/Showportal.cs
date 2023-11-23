using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showportal : MonoBehaviour
 {
    public GameObject portal7;

    public void ActivatePortal() {
        if (portal7 != null) {
            portal7.SetActive(true);
        }
    }
}
