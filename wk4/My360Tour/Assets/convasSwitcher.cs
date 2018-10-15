using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class convasSwitcher : MonoBehaviour
{

    public GameObject menuCanvas, tourConvas, videoConvas;
    /*
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }*/
    public Texture tex;
    public gotoX tour;
    public void BTN_switchToTour()
    {
        tour.currTour = 0;
        tour.prevTour = -1;
        tourConvas.SetActive(true);
        gameObject.SetActive(false);
    }
    public void BTN_switchToMenu()
    {
        tour.SphereWorld.GetComponent<VideoPlayer>().Stop();
        tour.resetCurr();
        //Debug.Log("inMenu");
        tour.SphereWorld.GetComponent<MeshRenderer>().material.mainTexture = tex;
        menuCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    public void BTN_switchToVideo()
    {
        tour.SphereWorld.GetComponent<videoController>().slider.value = 0f;
        videoConvas.SetActive(true);
        gameObject.SetActive(false);
    }

}
