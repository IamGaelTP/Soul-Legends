using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroVideoPlayer : MonoBehaviour
{
    VideoPlayer video;
    SceneChanger sceneManager;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        sceneManager = FindObjectOfType<SceneChanger>();


        video.url = System.IO.Path.Combine(Application.streamingAssetsPath, "studioIntro.mp4");
        Debug.Log(video.url);
    }

    void Start()
    {
        video.loopPointReached += LoadScene;
    }

    void LoadScene(VideoPlayer vp)
    {
        Invoke("WaitSeconds", 1f);  
    }

    void WaitSeconds()
    {
        sceneManager.LoadHomeScene();
    }
}
