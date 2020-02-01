using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playCutscene : MonoBehaviour
{
    public GameObject videoPlayer;
    public int stopVideo;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.SetActive(true);
        Destroy(videoPlayer, stopVideo);
    }
}
