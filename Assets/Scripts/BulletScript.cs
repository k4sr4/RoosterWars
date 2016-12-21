﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed = 1;
    public Sprite[] sprites;

    void Start() {
        int i = Random.Range(0, 4);
        GetComponent<SpriteRenderer>().sprite = sprites[i];
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if (other.tag == "Border2")
        {
            Destroy(this.gameObject);
        }
    }
}
