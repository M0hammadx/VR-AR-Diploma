using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;

[RequireComponent(typeof(VirtualButtonBehaviour))]
public class GenericVirtualButtonEvenet : MonoBehaviour, IVirtualButtonEventHandler
{

    public UnityEvent OnPressed, OnReleased;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        OnPressed.Invoke();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        OnReleased.Invoke();
    }

    void Start()
    {
        GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();



    }
}
