using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playCutscene : MonoBehaviour
{
    public GameObject videoPlayer;
    public int stopVideo;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
        StartCoroutine(Coroutine());
    }

    // Update is called once per frame
    IEnumerator Coroutine()
    {
        videoPlayer.SetActive(true);
        yield return new WaitForSeconds(23);
        Destroy(videoPlayer, stopVideo);
        SceneManager.LoadScene("SampleScene");
    }
}
