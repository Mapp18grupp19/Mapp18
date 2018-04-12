using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public LineRenderer lineRenderer;

    private bool mousePressed;
    private Vector3 mousePosition;
    private List<Vector3> vertexList = new List<Vector3>();

    private void Start () {
    }

    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            mousePressed = true;
            lineRenderer.positionCount = 0;
            vertexList.RemoveRange(0, vertexList.Count);
        }

        if (Input.GetMouseButton(0)) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            if (!vertexList.Contains(mousePosition)) {
                vertexList.Add(mousePosition);
                lineRenderer.positionCount = vertexList.Count;
                lineRenderer.SetPosition(vertexList.Count - 1, vertexList[vertexList.Count - 1]);
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            mousePressed = false;
        }
	}
}
