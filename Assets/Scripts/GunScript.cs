using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public bool goUp = true;
    public float speed = 4f;
    public GameObject bullet;
    public int shootDelay = 10;
    int initialDelay;
    int t = 0;
    List<GameObject> bullets = new List<GameObject>();

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
            //transform.Translate(Vector2.up * speed * Time.deltaTime);
            transform.position = new Vector2(-8, Mathf.Sin(t) * speed*4.1f);
        else
            //transform.Translate(Vector2.down * speed * Time.deltaTime);
            transform.position = new Vector2(-8, Mathf.Sin(t) * -speed*4.1f);

        t++;
        shootDelay--;

        if (shootDelay == 0)
        {
            GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
            bullets.Add(b);
            shootDelay = initialDelay;
        }
    }

    void OnDestroy(){
        for (int i = 0; i < bullets.Count; i++)
        {
            Destroy(bullets[i].gameObject);
        }
    }
}
