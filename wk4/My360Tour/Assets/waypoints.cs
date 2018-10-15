using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class waypoints : MonoBehaviour
{
    /*
    [System.Serializable]
    public class tour
    {
        public Texture arr;
        public GameObject[] ar;

    }
    */
    public GameObject SphereWorld;
    GameObject point1, point2;
    public int currTour;
    int prevTour = -1;
    public Texture[] texs;
    Material mainMat;
    // Use this for initialization
    void Start()
    {
        mainMat = SphereWorld.GetComponent<MeshRenderer>().material;
        point1 = transform.GetChild(currTour * 2).gameObject;
        point2 = transform.GetChild(currTour * 2 + 1).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BTN_redPoint();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            BTN_bluePoint();
        }

        if (currTour == prevTour) return;

        mainMat.mainTexture = texs[currTour];

        if (prevTour >= 0)
        {

            transform.GetChild(prevTour * 2).gameObject.SetActive(false);
            transform.GetChild(prevTour * 2 + 1).gameObject.SetActive(false);
        }
        switch (currTour)
        {
            case 0:
                transform.GetChild(currTour * 2).gameObject.SetActive(true);
                transform.GetChild(currTour * 2 + 1).gameObject.SetActive(true);

                break;

            case 1:
                transform.GetChild(currTour * 2).gameObject.SetActive(true);
                //     transform.GetChild(currTour * 2 + 1).gameObject.SetActive(true);

                break;
            case 2:
                //    transform.GetChild(currTour * 2).gameObject.SetActive(true);
                transform.GetChild(currTour * 2 + 1).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void BTN_bluePoint()
    {
        switch (currTour)
        {
            case 0:
                prevTour = currTour;
                currTour = 2;
                break;

            case 1:
                prevTour = currTour;
                currTour = 0;
                break;
            default:
                break;
        }
    }

    public void BTN_redPoint()
    {
        switch (currTour)
        {
            case 0:
                prevTour = currTour;
                currTour = 1;
                break;

            case 2:
                prevTour = currTour;
                currTour = 0;
                break;

            default:
                break;
        }
    }
}
