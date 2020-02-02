using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public static Speed instance;
    public float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
