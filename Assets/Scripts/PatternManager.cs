using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour {

    public int state = 1;
    public GameObject bullet;
    public int bulletNum = 5;

	// Use this for initialization
	void Start () {
        if (state == 1) {
            float x, y;            
            for (int i = 0; i < bulletNum / 5; i++)
            {                                
                for (float j = 0; j < 9; j += 1.8f)
                {
                    x = Random.Range(-i - 9f, -i - 8f);
                    y = Random.Range(j, j + 1.8f);
                    print(y);
                    Instantiate(bullet, new Vector2(x, y - 4.5f), Quaternion.identity);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
