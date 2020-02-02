using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetArm : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("tamere");
        SceneManager.LoadScene("LastScene");
        // LoadSceneByName("LastScene");
    }
}

