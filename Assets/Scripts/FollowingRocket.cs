using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingRocket : MonoBehaviour {

    Transform target;
    public float moveSpeed = 4f;

    public int manaDamage = 10;
    public int hpDamage = 10;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int playerHP = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().hp;
            int playerMana = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().mana;

            if (playerHP > 0)
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().hp -= hpDamage;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().damage += hpDamage;
            }
            if (playerMana > 0)
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().mana -= manaDamage;
            Destroy(this.gameObject);
        }
    }
}
