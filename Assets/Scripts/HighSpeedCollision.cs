using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighSpeedCollision : MonoBehaviour
{
    Vector3 oldPos;
    Vector3 currPosition;

    public bool canMove = true;

    void Start()
    {
        oldPos = transform.position;      
    }

    void Update()
    {        
        currPosition = transform.position;
        //print(currPosition.x);
        if (currPosition.x < -7.5 && currPosition.y < -4.5)
        {
            canMove = false;
            transform.position = new Vector2(-7.5f, -4.5f);
        }
        else if (currPosition.x > 7.5 && currPosition.y < -4.5)
        {
            canMove = false;
            transform.position = new Vector2(7.5f, -4.5f);
        }
        else if (currPosition.x < -7.5 && currPosition.y > 4.5)
        {
            canMove = false;
            transform.position = new Vector2(-7.5f, 4.5f);
        }
        else if (currPosition.x > 7.5 && currPosition.y > 4.5)
        {
            canMove = false;
            transform.position = new Vector2(7.5f, 4.5f);
        }
        else if (currPosition.x < -7.5)
        {            
            canMove = false;
            transform.position = new Vector2(-7.5f, currPosition.y);
        }
        else if (currPosition.x > 7.5)
        {            
            canMove = false;
            transform.position = new Vector2(7.5f, currPosition.y);
        }
        else if (currPosition.y < -4.5)
        {
            canMove = false;
            transform.position = new Vector2(currPosition.x, -4.5f);
        }
        else if (currPosition.y > 4.5)
        {
            canMove = false;
            transform.position = new Vector2(currPosition.x, 4.5f);
        }        
        //RaycastHit2D hit;

        //hit = Physics2D.Raycast(oldPos, Vector2.left, Mathf.Infinity);

        //if (hit.collider != null){
        //    print("HIT");
        //    transform.position = hit.point;
        //}
    }
}
