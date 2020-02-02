using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedP : MonoBehaviour
{
    public static SpeedP instance;
    public float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;
    }

}
