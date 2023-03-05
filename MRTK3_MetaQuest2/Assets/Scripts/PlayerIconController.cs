using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerIconController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private float scaleValue = 3.0f;
    private void Start() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.DOFade(0, 2.0f).SetEase(Ease.InQuart).SetLoops(-1, LoopType.Yoyo);                     
    }

    public void StandardScaleUp()
    {
        this.transform.localScale += new Vector3(15.0f, 0, 15.0f);
    }

    public void StandardScaleDown()
    {
        this.transform.localScale -= new Vector3(15.0f, 0, 15.0f);
    }
}
