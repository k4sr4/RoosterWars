using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public int[] damage;
    public int[] manaCost;

    //public GameObject rooster;

    public void Attack(int index)
    {                
        if (manaCost[index] <= GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().totalMana)
        {
            if (index == 4)
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().totalMana -= manaCost[index];
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().hp += damage[index];

                if (manaCost[index] == 0)
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().manaLoss.GetComponent<Text>().text = manaCost[index].ToString();
                else
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().manaLoss.GetComponent<Text>().text = "-" + manaCost[index].ToString();

                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().manaLoss.SetActive(true);
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().hpLoss.GetComponent<Text>().text = "+" + damage[index].ToString();
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().hpLoss.SetActive(true);
                StartCoroutine("WaitArmor");
            }
            else
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().totalMana -= manaCost[index];
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().enemyHp -= damage[index];

                if(manaCost[index] == 0)
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().manaLoss.GetComponent<Text>().text = manaCost[index].ToString();
                else
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().manaLoss.GetComponent<Text>().text = "-" + manaCost[index].ToString();

                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().manaLoss.SetActive(true);

                if(damage[index] == 0)
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().enemyHPLoss.GetComponent<Text>().text = damage[index].ToString();
                else
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().enemyHPLoss.GetComponent<Text>().text = "-" + damage[index].ToString();

                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().enemyHPLoss.SetActive(true);
                StartCoroutine("Wait");
            }
        }
        else
        {
            StartCoroutine("Cross");
        }

        //Mammad
        //if (index == 0)
        //{
        //    rooster.GetComponent<Animator>().SetTrigger("Punch");
        //}
        //else if (index == 1)
        //{

        //}
    }

    IEnumerator Cross()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().myTurn = true;
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().manaLoss.SetActive(false);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().enemyHPLoss.SetActive(false);
    }

    IEnumerator WaitArmor()
    {
        yield return new WaitForSeconds(2f);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().myTurn = true;
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().manaLoss.SetActive(false);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().hpLoss.SetActive(false);
    }
}
