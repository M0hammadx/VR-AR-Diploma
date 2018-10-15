using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoX : MonoBehaviour
{

    [System.Serializable]
    public class Tour
    {
        public Texture tex;
        public GameObject[] wayPoints;

    }

    public Tour[] tours;
    public GameObject SphereWorld;
    public Material mainMat;
    public int currTour;
    public int prevTour;


    void Start()
    {
        //Texture[] texs = Resources.LoadAll<Texture>("tour");
        //Debug.Log(texs.Length);
        //tours = new Tour[texs.Length];
        //for (int i = 0; i < texs.Length; i++)
        //{
        //    tours[i].tex = texs[i];
        //}

        mainMat = SphereWorld.GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (prevTour == currTour) return;
        BTN_goto(currTour);

    }
    public void BTN_goto(int x)
    {

        if (prevTour >= 0)
        {

            foreach (var item in tours[prevTour].wayPoints)
            {
                item.SetActive(false);
            }

            //Debug.Log(prevTour + " " + tours[prevTour].wayPoints.Length);
        }
        currTour = x;
        prevTour = currTour;
        //Debug.Log(currTour + " " + tours[currTour].wayPoints.Length);
        foreach (var item in tours[currTour].wayPoints)
        {
            item.SetActive(true);


        }
        mainMat.mainTexture = tours[currTour].tex;

    }
    public void resetCurr()
    {
        //Debug.Log("inReset");

        foreach (var item in tours[currTour].wayPoints)
        {
            item.SetActive(false);
            //Debug.Log("inLoop");
        }

    }

}
