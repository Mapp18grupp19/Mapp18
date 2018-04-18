using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollision : MonoBehaviour {

    public Collider2D startCollider;
    public Collider2D[] middleColliders;

    private int middlesCollected = 0;

    private void Update () {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (startCollider.OverlapPoint(mousePosition))
            transform.parent.GetComponent<DrawLine>().start = true;
        else if (!transform.parent.GetComponent<DrawLine>().drawing){
            transform.parent.GetComponent<DrawLine>().start = false;
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("MiddleCircle")) {
            Debug.Log("middlecollide");
            other.gameObject.SetActive(false);
            middlesCollected++;
        }

        if (other.CompareTag("EndCircle")) {
            if (middlesCollected >= middleColliders.Length) {
                transform.parent.GetComponent<DrawLine>().Finish();
            }
        }
    }

}