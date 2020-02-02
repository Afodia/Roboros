using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Player")
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
