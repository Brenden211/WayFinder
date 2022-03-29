using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public bool flashlightActive = false;

    private void Update()
    {
        if (Input.GetButtonDown("Flashlight") && flashlightActive == false)
        {
            flashlightActive = true;
        }

        else if (Input.GetButtonDown("Flashlight") && flashlightActive == true)
        {
            flashlightActive = false;
        }
    }
}
