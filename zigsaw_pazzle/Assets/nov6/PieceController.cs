using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Camera mainCamera;

    void OnMouseDown()
    {
        mainCamera = Camera.main;

        screenPoint = mainCamera.WorldToScreenPoint(transform.position);

        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        offset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(x, y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        Debug.Log(x.ToString() + " - " + y.ToString());

        Vector3 currentScreenPoint = new Vector3(x, y, screenPoint.z);

        Vector3 currentPosition = mainCamera.ScreenToWorldPoint(currentScreenPoint) + offset;

        transform.position = currentPosition;
    }
}
