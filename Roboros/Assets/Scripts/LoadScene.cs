using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(0, 0, 0);
            GameObject.Find("Player").GetComponent<PlayerController2D>().currState = PlayerController2D.state.TWO_ARMS;
            GameObject.Find("hand").GetComponent<SpriteRenderer>().enabled = false;
    }
}
