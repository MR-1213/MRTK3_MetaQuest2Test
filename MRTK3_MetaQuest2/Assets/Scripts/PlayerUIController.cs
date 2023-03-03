using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject canvas;
    private bool canvasActive = false;

    private void Update() 
    {
        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            canvasActive = !canvasActive;
            canvas.SetActive(canvasActive);

            if (mainCamera != null)
            {
                canvas.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 2.0f;
                canvas.transform.rotation = Quaternion.Euler(0, mainCamera.transform.rotation.eulerAngles.y, 0);
            }
        }
    }
}

