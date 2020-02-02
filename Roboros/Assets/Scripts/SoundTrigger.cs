using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public string name;
    public string theme;
    
    void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<AudioManager>().Stop(theme);
        FindObjectOfType<AudioManager>().Play(name);
    }

    void OnTriggerExit2D(Collider2D collision) {
        FindObjectOfType<AudioManager>().Stop(name);
        FindObjectOfType<AudioManager>().Play(theme);
    }
}
