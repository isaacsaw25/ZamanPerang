using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdjustScript : MonoBehaviour
{
    public GameObject mainCamera;
    public float scrollSpeed;
    public string side;
    private PanningHandler panningHandler;

    private void Start()
    {
        panningHandler = mainCamera.GetComponent<PanningHandler>();
    }

    void OnMouseEnter()
    {
        if (side == "left")
        {
            panningHandler.SetScrollDirection(-scrollSpeed);
            // Debug.Log("Trying to scroll left");
        }
        else if (side == "right")
        {
            panningHandler.SetScrollDirection(scrollSpeed);
            // Debug.Log("Trying to scroll right");
        }
    }

    void OnMouseExit()
    {
        panningHandler.SetScrollDirection(0);
        // Debug.Log("Screen should stop moving");
    }
}
