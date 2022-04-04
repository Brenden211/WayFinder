using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    UnityEvent onInteract;

    public GameObject interactCanvas;
    public LayerMask interactableMask;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableMask))
        {

            if (hit.collider.GetComponent<Interactable>() != false)
            {
                interactCanvas.SetActive(true);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("Interact!");
                    onInteract.Invoke();
                    interactCanvas.SetActive(false);
                }
            }
        }
    }
}
