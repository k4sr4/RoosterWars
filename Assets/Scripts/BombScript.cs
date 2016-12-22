using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    Animator anim;
    public int bombDelay = 50;
    public float speed = 4f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {                        
        if(bombDelay == 0)
        {            
            anim.SetTrigger("Explode");
        }
        else
        {
            bombDelay--;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
	}
}
