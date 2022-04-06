using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenText : MonoBehaviour
{
    public Canvas canvas;
    public bool isHidden;
    public LayerMask hiddenTextMask;
    public Flashlight flashlight;
    public Color _color;
    public GameObject startingKey;

    void Start()
    {
        startingKey.SetActive(false);
        _color = GetComponent<Text>().color;
        GetComponent<Text>().color = _color;
        isHidden = true;
        _color.a = 0f;
    }


    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10, hiddenTextMask))
        {

            if (hit.collider.GetComponent<HiddenText>() != false && flashlight.flashlightActive == true)
            {
                RevealText();
            }
        }
    }

    void RevealText()
    {
        GetComponent<Text>().color = _color;
        _color.a = 1f;
        isHidden = false;
        SpawnKey();
    }

    void SpawnKey()
    {
        startingKey.SetActive(true);
    }
}
