using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool flashlightActive;
    public GameObject SpotLight;

    void Start()
    {
        flashlightActive = false;
        SpotLight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("f") && flashlightActive == false)
        {
            ActivateFlashlight();
        }
        else if (Input.GetKeyDown("f") && flashlightActive == true)
        {
            flashlightActive = false;
            SpotLight.SetActive(false);
        }
    }

    void ActivateFlashlight()
    {
        flashlightActive = true;
        SpotLight.SetActive(true);
    }
}
