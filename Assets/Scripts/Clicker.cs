using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Properties;

public class Clicker : MonoBehaviour
{
    [Header("Animation Settings")]
    public Ease ease;

    [Header("VFX")]
    public ParticleSystem particles;


    public AudioSource audioSource;

    private int clicks = 0;
    public int Clicks
    {
        get
        {
            return clicks;
        }
        set
        {
            particles.Emit(value - clicks);
            clicks = value;
            UIManager.Instance.UpdateClicks(clicks);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Clicks++;
        audioSource.Play();
        //UIManager.Instance.UpdateClicks(clicks);
        transform.DOScale(Vector3.one, 0.1f).ChangeStartValue(Vector3.one * 1.5f).SetEase(ease); //.SetLoops(2, LoopType.Yoyo);
        
    }
}
