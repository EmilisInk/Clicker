using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Clicker : MonoBehaviour
{
    [Header("Animation Settings")]
    public Ease ease;

    public AudioSource audioSource;

    private int clicks = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        clicks++;
        audioSource.Play();
        UIManager.Instance.UpdateClicks(clicks);
        transform.DOScale(Vector3.one, 0.1f).ChangeStartValue(Vector3.one * 1.5f).SetEase(ease); //.SetLoops(2, LoopType.Yoyo);
        
    }
}
