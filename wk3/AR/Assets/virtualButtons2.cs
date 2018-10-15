using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
public class virtualButtons2 : MonoBehaviour, IVirtualButtonEventHandler
{

    //public UnityEvent b;
    int currIdx;
    GameObject[] spawnies; public GameObject[] temp;
    public bool holdin, holdout, rotleft, rotright;
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "ZoomIn")
        {
            holdin = true;
        }
        else if (vb.VirtualButtonName == "ZoomOut")
        {

            holdout = true;
        }
        else if (vb.VirtualButtonName == "RotateRight")
        {
            rotright = true;
            RotateRight();
        }
        else if (vb.VirtualButtonName == "RotateLeft")
        {
            rotleft = true;
            RotateLeft();
        }

    }

    private void RotateLeft()
    {
        spawnies[currIdx].transform.Rotate(0, -1, 0);
    }

    private void RotateRight()
    {
        spawnies[currIdx].transform.Rotate(0, 1, 0);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        holdin = false;
        holdout = false;
        rotright = false;
        rotleft = false;
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

    // Update is called once per frame
    void Update()
    {
        if (holdout)
        {
            ScaleUp();
        }
        else if (holdin)
        {
            ScaleDown();
        }
        else if (rotleft)
        {
            RotateLeft();
        }
        else if (rotright)
        {
            RotateRight();
        }
    }
    public void ScaleUp()
    {
        spawnies[currIdx].transform.localScale += Vector3.one * 0.1f;
    }

    private void ScaleDown()
    {
        if (spawnies[currIdx].transform.localScale.x > 0)
            spawnies[currIdx].transform.localScale -= Vector3.one * 0.1f;
    }
}
