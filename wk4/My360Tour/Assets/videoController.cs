using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class videoController : MonoBehaviour
{

    // Use this for initialization
    public Slider slider;
    VideoPlayer vid;
    void Start()
    {
        vid = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs((float)vid.time - ((float)vid.clip.length) * slider.value) > 0.1)
        {
            vid.time = vid.clip.length * slider.value;

        }
        else
        {

            slider.value = (float)(vid.time / vid.clip.length);
        }


    }
}
