using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public bool goUp = true;
    public float speed = 2f;
    public GameObject bullet;
    public int shootDelay = 10;
    int initialDelay;

	// Use this for initialization
	void Start () {
        initialDelay = shootDelay;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > 4.35f)
            goUp = false;

        if (transform.position.y < -4.35f)
            goUp = true;

        if (goUp)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.down * speed * Time.deltaTime);

        shootDelay--;

        if (shootDelay == 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            shootDelay = initialDelay;
        }
    }
}
