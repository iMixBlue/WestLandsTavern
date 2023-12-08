using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
     public float minX = -6.5f; // 这些值应根据你的需求进行调整
    public float maxX = 6.5f;
    public float minY = -6.5f;
    public float maxY = 6.5f;
    private void Update() {
        // Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        // Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        // Debug.Log(cursorPosition);
    }

    void OnMouseDown()
    {
        
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        cursorPosition.x = Mathf.Clamp(cursorPosition.x, minX, maxX);
        cursorPosition.y = Mathf.Clamp(cursorPosition.y, minY, maxY);
        transform.position = cursorPosition;
    }

    void OnMouseUp()
    {
        // 在这里处理放置逻辑
    }
}
