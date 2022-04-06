using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.Animations;

public class Interactor : MonoBehaviour
{
    UnityEvent onInteract;

    public LayerMask flashlightMask;
    public LayerMask interactableMask;
    public LayerMask Mask;
    public LayerMask startingKeyMask;
    public LayerMask doorMask;
    public LayerMask key1Mask;

    public GameObject interactCanvas;
    public GameObject playerFlashLight;
    public GameObject startingKey;
    public GameObject flashlightModel;
    public GameObject startingKeyModel;
    public GameObject noKeyMessage;
    public GameObject key1Model;
    public GameObject key1;

    public Animator doorAnimator;

    public bool hasStartingKey;
    public bool doorOpen;
    public bool hasKey1;
    public bool door1Open;

    private void Start()
    {
        interactCanvas.SetActive(false);
        playerFlashLight.SetActive(false);
        startingKey.SetActive(false);
        flashlightModel.SetActive(true);
        startingKeyModel.SetActive(true);
        noKeyMessage.SetActive(false);
        key1.SetActive(false);
        key1Model.SetActive(true);

        hasStartingKey = false;
        doorOpen = false;
        hasKey1 = false;
        door1Open = false;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, flashlightMask))
        {

            if (hit.collider.GetComponent<Interactable>() != false)
            {
                interactCanvas.SetActive(true);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Input.GetKeyDown("e"))
                {
                    playerFlashLight.SetActive(true);
                    interactCanvas.SetActive(false);
                    flashlightModel.SetActive(false);
                    onInteract.Invoke();
                }
            }
        }
        else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, startingKeyMask))
        {
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                interactCanvas.SetActive(true);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Input.GetKeyDown("e"))
                {
                    startingKey.SetActive(true);
                    interactCanvas.SetActive(false);
                    startingKeyModel.SetActive(false);
                    onInteract.Invoke();
                    hasStartingKey = true;
                }
            }
        }
        else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5, doorMask))
        {
            if (hit.collider.GetComponent<Interactable>() != false && doorOpen == false && hasStartingKey == true || hasKey1 == true)
            {
                interactCanvas.SetActive(true);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Input.GetKeyDown("e") && hasStartingKey == true)
                {
                    hasStartingKey = false;
                    doorOpen = true;
                    interactCanvas.SetActive(false);
                    doorAnimator.SetBool("DoorOpen", true);
                    startingKey.SetActive(false);
                    onInteract.Invoke();
                }
                else if (Input.GetKeyDown("e") && hasStartingKey == false)
                {
                    noKeyMessage.SetActive(true);
                    onInteract.Invoke();
                }
            }
            else if (hit.collider.GetComponent<Interactable>() != false && door1Open == false && doorOpen == true)
            {
                interactCanvas.SetActive(true);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Input.GetKeyDown("e") && hasKey1 == true)
                {
                    door1Open = true;
                    interactCanvas.SetActive(false);
                    doorAnimator.SetBool("Door1Open", true);
                    key1.SetActive(false);
                    onInteract.Invoke();
                }
                else if (Input.GetKeyDown("e") && hasKey1 == false)
                {
                    noKeyMessage.SetActive(true);
                    onInteract.Invoke();
                }
            }
        }
        else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5, key1Mask))
        {
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                hasKey1 = true;
                interactCanvas.SetActive(true);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Input.GetKeyDown("e"))
                {
                    hasKey1 = false;
                    key1.SetActive(true);
                    interactCanvas.SetActive(false);
                    key1Model.SetActive(false);
                    onInteract.Invoke();
                    hasKey1 = true;
                }
            }
        }
        else if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5, interactableMask))
        {
            interactCanvas.SetActive(false);
            noKeyMessage.SetActive(false);
        }
    }
}
