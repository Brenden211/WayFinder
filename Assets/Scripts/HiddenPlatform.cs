using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HiddenPlatform : MonoBehaviour
{
    UnityEvent onInteract;

    public LayerMask hiddenPlatformMask;
    public Flashlight flashlight;
    public GameObject platform;

    public bool platformIsHidden;

    void Start()
    {
        platformIsHidden = true;
        platform.SetActive(false);
    }


    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 20, hiddenPlatformMask))
        {
            onInteract = hit.collider.GetComponent<Interactable>().onInteract;
            if (hit.collider.GetComponent<BoxCollider>() != false && flashlight.flashlightActive == true)
            {
                RevealPlatform();
                onInteract.Invoke();

            }
        }
    }

    void RevealPlatform()
    {
        platform.SetActive(true);
        platformIsHidden = false;
    }
}
