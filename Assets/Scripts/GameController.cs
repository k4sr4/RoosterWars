using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public int hp = 100;
    public int mana = 30;
    public int totalMana = 0;
    public Text hpText, manaText;
    public Slider manaSlider;
    public Slider healthSlider;
    public GameObject manaHandle, healthHandle, manaFill, healthFill;

    public bool myTurn = true;
    public GameObject pattern;
    public GameObject slider;

    IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        coroutine = Wait(5f);
        StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
        if (totalMana < 0)
            totalMana = 0;

        if (hp < 0)
            hp = 0;

        hpText.text = hp.ToString();
        manaText.text = totalMana.ToString();
        manaSlider.value = mana;

        if (mana == 0)
        {
            manaHandle.SetActive(false);
            manaFill.SetActive(false);
        }
        else
        {
            manaHandle.SetActive(true);
            manaFill.SetActive(true);
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Execute();
    }

    void Execute()
    {        
        if (myTurn && !pattern.activeInHierarchy)
        {
            Instantiate(pattern, pattern.transform.position, Quaternion.identity);
            slider.SetActive(true);
        }
        else if (!myTurn && !pattern.activeInHierarchy)
        {
            slider.SetActive(false);
            totalMana += mana;
            print("Attack!");
        }

        StartCoroutine("WaitEndTurn");
    }

    IEnumerator WaitEndTurn()
    {
        if(myTurn)
            yield return new WaitUntil(() => !myTurn);
        else
            yield return new WaitUntil(() => myTurn);

        Execute();
    }
}
