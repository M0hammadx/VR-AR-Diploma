using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{
    int sceneNo;
    // Use this for initialization
    void Start()
    {
        sceneNo = SceneManager.sceneCountInBuildSettings;
    }

    public void BTN_changeScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % sceneNo);
    }


}
