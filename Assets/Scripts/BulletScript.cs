using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {

    public float maxSpeed, minSpeed;
    float speed = 1;
    public Sprite[] sprites;

    public int manaDamage = 10;
    public int hpDamage = 10;    

    void Start() {
        int i = Random.Range(0, 4);
        GetComponent<SpriteRenderer>().sprite = sprites[i];

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
            int playerHP = GameObject.FindGameObjectWithTag("Manager").GetComponent<PatternManager>().hp;
            int playerMana = GameObject.FindGameObjectWithTag("Manager").GetComponent<PatternManager>().mana;

            if (playerHP > 0)
                GameObject.FindGameObjectWithTag("Manager").GetComponent<PatternManager>().hp -= hpDamage;
            if (playerMana > 0)
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<PatternManager>().mana -= manaDamage;                
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "Border2")
        {
            Destroy(this.gameObject);
        }
    }
}
