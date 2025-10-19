using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] // show in inspector
    private TextMeshProUGUI clickText;
    [SerializeField]
    private TextMeshProUGUI cps;

    private float Timer = 0f;
    private int cpsRn;
    private float updateInterval = 1f;


    void Awake() //before start
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("More than one UI Manager detected");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= updateInterval)
        {
            cps.text = "CPS: " + cpsRn.ToString();
            Timer = 0f;
            cpsRn = 0;
        }
    }

    public void UpdateClicks(int clicks)
    {
        cpsRn++;

        clickText.text = clicks.ToString();

    }
}
