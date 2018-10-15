using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
public class virtualButtons : MonoBehaviour, IVirtualButtonEventHandler
{

    //public UnityEvent b;
    int currIdx;
    GameObject[] spawnies; public GameObject[] temp;
    bool hold;
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.name == "reset")
        {
            reset();
        }
        else if (vb.name == "sizer")
        {
            ScaleUp();
            hold = true;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        hold = false;
    }

    public void BTN_changeChar()
    {
        // Debug.Log("in");
        currIdx++;
        currIdx %= temp.Length;
        // Instantiate(temp[0], transform).transform.localPosition=Vector3.zero;

        reset();
    }
    // Use this for initialization
    void Start()
    {
        spawnies = new GameObject[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            spawnies[i] = Instantiate(temp[i], transform);
            spawnies[i].SetActive(false);
        }

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }
    }
    public void reset()
    {
        spawnies[currIdx].transform.rotation = Quaternion.identity;
        spawnies[currIdx].transform.localPosition = Vector3.zero;
        spawnies[currIdx].transform.localScale = Vector3.one;
        spawnies[currIdx].SetActive(true);

        for (int i = 0; i < temp.Length; i++)
        {
            if (i != currIdx)
            {
                spawnies[i].SetActive(false);
            }
        }



    }

    public void ScaleUp()
    {
        spawnies[currIdx].transform.localScale += Vector3.one * 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (hold)
        {
            ScaleUp();
        }
    }
}
