using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquiggleCollision : MonoBehaviour {
    
    void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag("Line")){
            other.transform.parent.GetComponent<DrawLine>().SquiggleCollide();
        }
    }
}
