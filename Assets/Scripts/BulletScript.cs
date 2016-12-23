using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {

    public float maxSpeed, minSpeed;
    float speed = 1;

    public int manaDamage = 10;
    public int hpDamage = 10;    

    void Start() {
        speed = Random.Range(minSpeed, maxSpeed);
    }

	// Update is called once per frame
	void Update () {        
        transform.Translate(Vector2.right * speed * Time.deltaTime);        
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
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().mana -= manaDamage;                
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "Border2")
        {
            Destroy(this.gameObject);
        }
    }
}
