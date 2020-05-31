using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAll : MonoBehaviour
{
    void OnTriggerEnter (Collider col) {
        if(col.gameObject.tag == "Cubes") {
            col.gameObject.SetActive(false);
        }
    }
}
