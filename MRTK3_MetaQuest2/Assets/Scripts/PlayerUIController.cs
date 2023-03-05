using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerUIController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject canvas;

    [SerializeField] private PlayerIconController playerIconController;
    [SerializeField] private Camera mapCamera;
    [SerializeField] private RectTransform menuPlate;
    [SerializeField] private RectTransform mapPlate;
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

    public void OnDisplayMapButton()
    {
        menuPlate.DOAnchorPos(new Vector2(-400, 0), 1.0f).SetEase(Ease.OutCubic);

        mapPlate.gameObject.SetActive(true);
        mapPlate.DOAnchorPos(new Vector2(345, 0), 1.0f).SetEase(Ease.OutCubic);
    }

    public void OnExpansionButton()
    {
        float newValue = mapCamera.fieldOfView + 10.0f;
        if(newValue > 110.0f)
        {
            newValue = 110.0f;
        }
        mapCamera.fieldOfView = newValue;

        playerIconController.StandardScaleDown();
    }

    public void OnContractionButton()
    {
        float newValue = mapCamera.fieldOfView - 10.0f;
        if(newValue < 30.0f)
        {
            newValue = 30.0f;
        }
        mapCamera.fieldOfView = newValue;

        playerIconController.StandardScaleUp();
    }

    public void OnBackButton(RectTransform otherPlate)
    {
        menuPlate.DOAnchorPos(new Vector2(0, 0), 0.4f).SetEase(Ease.OutCubic);

        otherPlate.DOAnchorPos(new Vector2(0, 0), 0.4f).SetEase(Ease.OutCubic)
        .OnComplete(() => otherPlate.gameObject.SetActive(false));
    }

}

