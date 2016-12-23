using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternManager : MonoBehaviour {   
    public int state = 1;
    public float[] time;
    public int[] mana;

    public GameObject bullet;
    public int bulletNum = 5;
    public int waves = 1;
    public float timeInterval1 = 3f;

    public GameObject fire;
    public GameObject safeZone;    
    public float cooldown = 2f;
    public float timeInterval2 = 1f;
    int safeNum = 1;
    List<GameObject> fires = new List<GameObject>();
    List<GameObject> safeZones = new List<GameObject>();

    public GameObject rocket;
    public int rocketNum = 3;

    public GameObject gun;

    public GameObject[] bombs;
    int bombNum = 0;
    public float bombTime = 1f;

	// Use this for initialization
	void Start () {
        state = Random.Range(1, 6);

        if (state == 1) {                       
            StartCoroutine("GenerateBullets");            
        }

        if (state == 2)
        {
            StartCoroutine("GenerateFire");
        }

        if (state == 3)
        {
            for (int i = 0; i < rocketNum; i++)
            {
                float x, y;
                if (i % 2 == 0)
                {
                    x = Random.Range(-7.5f, -2f);
                    y = Random.Range(-4.5f, -1f);
                }
                else
                {
                    x = Random.Range(2f, 7.5f);
                    y = Random.Range(1f, 4.5f);
                }

                GameObject r = Instantiate(rocket, new Vector2(x, y), Quaternion.identity);
                r.transform.parent = gameObject.transform;
            }
        }

        if (state == 4)
        {
            GameObject gun1 = Instantiate(gun, new Vector2(-7.7f, 0f), Quaternion.identity);
            GameObject gun2 = Instantiate(gun, new Vector2(-7.7f, 0f), Quaternion.identity);
            gun2.GetComponent<GunScript>().goUp = false;
            gun1.transform.parent = gameObject.transform;
            gun2.transform.parent = gameObject.transform;
        }

        if(state == 5)
        {
            StartCoroutine("GenerateBomb");
        }

        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().mana = mana[state - 1];
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().manaSlider.maxValue = mana[state - 1];
        StartCoroutine("SessionTime");
	}

    IEnumerator SessionTime()
    {
        yield return new WaitForSeconds(time[state - 1]);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().myTurn = false;
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator GenerateBullets()
    {
        float x, y;
        for (int i = 0; i < bulletNum / 5; i++)
        {
            for (float j = 0; j < 9; j += 1.8f)
            {
                x = -8f;
                y = Random.Range(j, j + 1.8f);

                GameObject b = Instantiate(bullet, new Vector2(x, y - 4.5f), Quaternion.identity);
                b.transform.parent = gameObject.transform;
            }
        }

        waves--;
        yield return new WaitForSeconds(timeInterval1);
        if (waves > 0)
        {
            StartCoroutine("GenerateBullets");
        }
    }

    IEnumerator GenerateFire()
    {
        if (safeNum == 1)
        {            
            GameObject s = Instantiate(safeZone, new Vector2(-4f, 2f), Quaternion.identity);          
            safeZones.Add(s);
            s.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(timeInterval2);
            for (float x = -7.5f; x < 8.5f; x++)
            {
                for (float y = 4.5f; y > -5.5f; y--)
                {
                    if(y == 1.5)
                    {
                        if (x == -4.5 || x == -3.5)
                            continue;
                    }
                    if (y == 2.5)
                    {
                        if (x == -4.5 || x == -3.5)
                            continue;
                    }

                    GameObject f = Instantiate(fire, new Vector2(x, y), Quaternion.identity);
                    fires.Add(f);
                    f.transform.parent = gameObject.transform;
                }
            }
        }
        else if (safeNum == 2)
        {
            GameObject s = Instantiate(safeZone, new Vector2(4f, 2f), Quaternion.identity);
            safeZones.Add(s);
            s.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(timeInterval2);
            for (float x = -7.5f; x < 8.5f; x++)
            {
                for (float y = 4.5f; y > -5.5f; y--)
                {
                    if (y == 1.5)
                    {
                        if (x == 4.5 || x == 3.5)
                            continue;
                    }
                    if (y == 2.5)
                    {
                        if (x == 4.5 || x == 3.5)
                            continue;
                    }

                    GameObject f = Instantiate(fire, new Vector2(x, y), Quaternion.identity);
                    fires.Add(f);
                    f.transform.parent = gameObject.transform;
                }
            }
        }
        else if (safeNum == 3)
        {
            GameObject s = Instantiate(safeZone, new Vector2(4f, -2f), Quaternion.identity);
            safeZones.Add(s);
            s.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(timeInterval2);
            for (float x = -7.5f; x < 8.5f; x++)
            {
                for (float y = 4.5f; y > -5.5f; y--)
                {
                    if (y == -1.5)
                    {
                        if (x == 4.5 || x == 3.5)
                            continue;
                    }
                    if (y == -2.5)
                    {
                        if (x == 4.5 || x == 3.5)
                            continue;
                    }

                    GameObject f = Instantiate(fire, new Vector2(x, y), Quaternion.identity);
                    fires.Add(f);
                    f.transform.parent = gameObject.transform;
                }
            }
        }
        else if (safeNum == 4)
        {
            GameObject s = Instantiate(safeZone, new Vector2(-4f, -2f), Quaternion.identity);
            safeZones.Add(s);
            s.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(timeInterval2);
            for (float x = -7.5f; x < 8.5f; x++)
            {
                for (float y = 4.5f; y > -5.5f; y--)
                {
                    if (y == -1.5)
                    {
                        if (x == -4.5 || x == -3.5)
                            continue;
                    }
                    if (y == -2.5)
                    {
                        if (x == -4.5 || x == -3.5)
                            continue;
                    }

                    GameObject f = Instantiate(fire, new Vector2(x, y), Quaternion.identity);
                    fires.Add(f);
                    f.transform.parent = gameObject.transform;
                }
            }
        }

        safeNum++;        
        yield return new WaitForSeconds(cooldown);

        for (int h = 0; h < fires.Count; h++)
        {
            Destroy(fires[h]);
        }
        for (int h = 0; h < safeZones.Count; h++)
        {
            Destroy(safeZones[h]);
        }

        if (safeNum < 5)
        {
            StartCoroutine("GenerateFire");
        }
    }

    IEnumerator GenerateBomb()
    {
        Instantiate(bombs[bombNum], bombs[bombNum].transform.position, Quaternion.identity);
        //bombs[bombNum].transform.parent = gameObject.transform;
        bombNum++;
        yield return new WaitForSeconds(bombTime);
        if (bombNum < bombs.Length)
            StartCoroutine("GenerateBomb");
    }
}
