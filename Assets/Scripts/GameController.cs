using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public int hp = 100;
    public int enemyHp = 100;
    public int mana = 30;
    public int totalMana = 0;
    public Text hpText, enemyHPText, manaText;
    public Slider manaSlider;
    public Slider healthSlider;
    public GameObject manaHandle, healthHandle, manaFill, healthFill;
    public GameObject manaGain, hpLoss, enemyHPLoss, manaLoss;
    public int damage = 0;

    public bool myTurn = true;
    public GameObject pattern;
    public GameObject slider;

    IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        coroutine = Wait(3f);
        StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
        if (totalMana < 0)
            totalMana = 0;

        if (hp < 0)
            hp = 0;

        if (enemyHp < 0)
            enemyHp = 0;

        if (totalMana > 100)
            totalMana = 100;

        if (hp > 100)
            hp = 100;

        if (enemyHp > 100)
            enemyHp = 100;

        hpText.text = hp.ToString();
        enemyHPText.text = enemyHp.ToString();
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
            manaGain.GetComponent<Text>().text = "+" + mana.ToString();
            manaGain.SetActive(true);

            if (damage == 0)
                hpLoss.GetComponent<Text>().text = damage.ToString();
            else
                hpLoss.GetComponent<Text>().text = "-" + damage.ToString();

            hpLoss.SetActive(true);
            StartCoroutine("DisableTexts");

            slider.SetActive(false);
            totalMana += mana;
            print("Attack!");
        }

        StartCoroutine("WaitEndTurn");
    }

    IEnumerator DisableTexts()
    {
        yield return new WaitForSeconds(1.5f);
        manaGain.SetActive(false);        
        hpLoss.SetActive(false);
        damage = 0;
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
