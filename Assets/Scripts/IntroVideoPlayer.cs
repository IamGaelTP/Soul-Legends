using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroVideoPlayer : MonoBehaviour
{
    VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();


        video.url = System.IO.Path.Combine(Application.streamingAssetsPath, "studioIntro.mp4");
        Debug.Log(video.url);
    }
}
