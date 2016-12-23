using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {    

    public void Attack(int manaCost)
    {                
        if (manaCost <= GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().totalMana)
        {           
            GameObject.FindGameObjectWithTag("Manager").GetComponent<GameController>().totalMana -= manaCost;
            StartCoroutine("Wait");
        }
        else
        {
            StartCoroutine("Cross");
        }
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
    }
}
