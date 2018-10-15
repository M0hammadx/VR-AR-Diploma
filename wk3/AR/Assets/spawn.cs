using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class spawn : MonoBehaviour
{

    //  public GameObject dbz1, dbz2;
    // Use this for initialization
    int noOfScenes;
    void Start()
    {
        noOfScenes = SceneManager.sceneCountInBuildSettings;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BTN_spawnObj(GameObject obj)
    {
        GameObject temp = Instantiate(obj, transform.position + transform.forward * 2f, Quaternion.identity);
        temp.transform.LookAt(Camera.main.transform);
        temp.transform.forward = -temp.transform.forward;
        Destroy(temp, 10f);

    }
    public void BTN_changeScene()
    {

        SceneManager.LoadSceneAsync((SceneManager.GetActiveScene().buildIndex + 1) % noOfScenes);
        //Debug.Log(noOfScenes);

    }


}
