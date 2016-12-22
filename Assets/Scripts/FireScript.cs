﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public int manaDamage = 10;
    public int hpDamage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int playerHP = GameObject.FindGameObjectWithTag("Manager").GetComponent<PatternManager>().hp;
            int playerMana = GameObject.FindGameObjectWithTag("Manager").GetComponent<PatternManager>().mana;

            if (playerHP > 0)
                GameObject.FindGameObjectWithTag("Manager").GetComponent<PatternManager>().hp -= hpDamage;
            if (playerMana > 0)
                GameObject.FindGameObjectWithTag("Manager").GetComponent<PatternManager>().mana -= manaDamage;
            Destroy(this.gameObject);
        }
    }
}
