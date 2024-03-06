using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public int direction = 2;
    
    void FixedUpdate() {
        transform.Translate(Vector3.right * .1f * direction);
    }

    void OnTriggerEnter(Collider col) {
        this.gameObject.SetActive(false);
    }
}
