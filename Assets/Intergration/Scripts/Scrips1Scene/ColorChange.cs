using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public int rgbCount;
    public bool canChangeColor;
    public CameraFollow cameraFollow;
    void Start()
    {
        GameObject mainCamera = GameObject.Find("MainCamera");
        cameraFollow = mainCamera.GetComponent<CameraFollow>();


    }

    // Update is called once per frame
    void Update()
    {
        if(rgbCount >= 3)
        {
            canChangeColor = true;
        }
    }

    public void ChangeColor()
    {
        if(canChangeColor)
        cameraFollow.SelectScreen(2);
    }
}
