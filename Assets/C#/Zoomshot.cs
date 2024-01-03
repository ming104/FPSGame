using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomshot : MonoBehaviour
{
    public GameObject ZoomPanel;
    //public GameObject Gun;
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        ZoomPanel.SetActive(false);
        //Gun.SetActive(true);
        MainCamera.fieldOfView = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1) && Player.gunon == true)
        {
            ZoomPanel.SetActive(true);
            //Gun.SetActive(false);
            MainCamera.fieldOfView = 30;

        }
        if(Input.GetMouseButtonUp(1) && Player.gunon == true)
        {
            ZoomPanel.SetActive(false); 
            //Gun.SetActive(true);
            MainCamera.fieldOfView = 60;
        }
    }
}
