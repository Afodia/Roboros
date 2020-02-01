using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 0f;
    private float pos = 0f;
    
    // Update is called once per frame
    void Update()
    {
        if (Speed.instance.speed != 0) {
            if (Speed.instance.speed > 0)
                pos += speed * 0.01f;
            else
                pos -= speed * 0.01f;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(pos, 0f);
        }
    }
}
