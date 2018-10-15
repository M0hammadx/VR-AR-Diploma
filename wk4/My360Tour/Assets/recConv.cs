using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recConv : MonoBehaviour {
    public RenderTexture cubMap,equrect;
    public Camera cam;
	// Use this for initialization
	void Start () {
       // cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        cam.RenderToCubemap(cubMap, 63);
        cubMap.ConvertToEquirect(equrect);
	}
}
