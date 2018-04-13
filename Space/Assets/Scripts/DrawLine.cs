using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public LineRenderer lineRenderer;
    public CircleCollider2D lineCollider;
    public GameController gameController;

    public bool start = false;
    public bool drawing = false;

    private bool mousePressed;
    private Vector3 mousePosition;
    private List<Vector3> vertexList = new List<Vector3>();

    private void Start () {
    }

    void Update () {
        Debug.Log(start);
        if (Input.GetMouseButtonDown(0)) {
            mousePressed = true;
            removeLine();
        }

        if (mousePressed == true && start == true) {
            drawing = true;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            if (!vertexList.Contains(mousePosition)) {
                vertexList.Add(mousePosition);
                lineRenderer.positionCount = vertexList.Count;
                lineRenderer.SetPosition(vertexList.Count - 1, vertexList[vertexList.Count - 1]);
                lineCollider.transform.position = vertexList[vertexList.Count - 1];
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            mousePressed = false;
            drawing = false;
            start = false;
        }
	}

    public void SquiggleCollide (){
        mousePressed = false;
        start = false;
        drawing = false;
        removeLine();
    }

    public void Finish () {
        gameController.score++;
        start = false;
        drawing = false;
        removeLine();
    }

    private void removeLine () {
        lineRenderer.positionCount = 0;
        vertexList.RemoveRange(0, vertexList.Count);
    }
}
