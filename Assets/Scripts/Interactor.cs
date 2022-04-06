using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.Animations;

public class Interactor : MonoBehaviour
{
    UnityEvent onInteract;

    public GameObject interactCanvas;
    public LayerMask interactableMask;
    public LayerMask keyMask;
    public LayerMask doorMask;
    public GameObject playerFlashLight;
    public GameObject startingKey;
    public GameObject flashlightModel;
    public GameObject startingKeyModel;
    public Animator doorAnimator;

    private void Start()
    {
        interactCanvas.SetActive(false);
        playerFlashLight.SetActive(false);
        startingKey.SetActive(false);
        flashlightModel.SetActive(true);
        startingKeyModel.SetActive(true);
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, interactableMask))
        {

            if (hit.collider.GetComponent<Interactable>() != false)
            {
                interactCanvas.SetActive(true);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Input.GetKeyDown("e"))
                {
                    playerFlashLight.SetActive(true);
                    flashlightModel.SetActive(false);
                    onInteract.Invoke();
                }
            }
        }
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, keyMask))
        {
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                interactCanvas.SetActive(true);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Input.GetKeyDown("e"))
                {
                    startingKey.SetActive(true);
                    startingKeyModel.SetActive(false);
                    onInteract.Invoke();
                }
            }
        }
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5, doorMask))
        {
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                interactCanvas.SetActive(true);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Input.GetKeyDown("e"))
                {
                    doorAnimator.SetBool("DoorOpen", true);
                    onInteract.Invoke();
                }
            }
        }
        else if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, interactableMask))
        {
            interactCanvas.SetActive(false);
        }
    }
}
