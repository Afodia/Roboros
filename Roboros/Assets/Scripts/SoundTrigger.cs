using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public string nameS;
    public string theme;
    
    void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<AudioManager>().Stop(theme);
        FindObjectOfType<AudioManager>().Play(nameS);
    }

    void OnTriggerExit2D(Collider2D collision) {
        FindObjectOfType<AudioManager>().Stop(nameS);
        FindObjectOfType<AudioManager>().Play(theme);
    }
}
