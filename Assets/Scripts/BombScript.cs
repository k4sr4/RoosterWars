using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    Animator anim;
    public int bombDelay = 50;
    public float speed = 4f;
    public int bombNum = 1;

    public int manaDamage = 10;
    public int hpDamage = 10;

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
            if (bombNum == 1)
                transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (bombNum == 2)
                transform.Translate(Vector2.down * speed * Time.deltaTime);

            if (bombNum == 3)
                transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (bombNum == 4)
                transform.Translate(new Vector2 (1f, -1f) * speed * Time.deltaTime);

            if (bombNum == 5)
                transform.Translate(new Vector2(-1f, 1f) * speed * Time.deltaTime);

            if (bombNum == 6)
                transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (bombNum == 7)
                transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (!GetComponent<SpriteRenderer>().enabled)
        {
            Destroy(this.gameObject);
        }
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
