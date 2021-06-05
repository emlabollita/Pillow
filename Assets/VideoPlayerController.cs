using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private GameObject preloader;
    private GameObject btnPlay;
    private bool videoPlayerInit = false;
    public string urlVideo;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = this.transform.Find("VideoPlayer").GetComponent<VideoPlayer>();
        preloader = this.transform.Find("Preloader").gameObject;
        btnPlay = this.transform.Find("BtnPlay").gameObject;

        preloader.SetActive(false);

        videoPlayer.url = urlVideo;
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayerInit) {
            if (videoPlayer.isPlaying)
            {
                preloader.SetActive(false);
            }
            else
            {
                preloader.SetActive(true);
            }
        }
    }

    public void StartVideo() {
        videoPlayerInit = true;
        btnPlay.SetActive(false);
        preloader.SetActive(true);
        videoPlayer.Play();
    }

    public void StopVideo() {
        videoPlayerInit = false;
        btnPlay.SetActive(true);
        preloader.SetActive(false);
        videoPlayer.Stop();
    }
}
