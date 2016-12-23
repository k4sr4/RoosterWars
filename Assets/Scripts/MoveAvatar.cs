using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAvatar : MonoBehaviour {

    Vector3 screenPoint;
    Vector3 offset;
    Vector3 scanPos;

    void Start()
    {
        scanPos = transform.position;
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);

        offset = scanPos - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }


    void OnMouseDrag()
    {
        GetComponent<HighSpeedCollision>().canMove = true;
        if (GetComponent<HighSpeedCollision>().canMove)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            scanPos = curPosition;
        }
    }    
}
