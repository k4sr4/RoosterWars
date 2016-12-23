using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAvatar : MonoBehaviour {

    public Sprite red, orig;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hazard")
        {
            GetComponent<SpriteRenderer>().sprite = red;
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = orig;
    }
}
