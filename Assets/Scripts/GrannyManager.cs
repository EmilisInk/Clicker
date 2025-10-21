using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrannyManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI countText;

    [Header("Settings")]
    public float bakeOffset = 2;
    public int cookies = 1;
    public int count = 0;
    public float price = 10;

    [Header("Clicker")]
    public Clicker clicker;

    void Start()
    {
        priceText.text = $"Price: {price}";
        countText.text = count.ToString();

        InvokeRepeating(nameof(Bake), 0, bakeOffset);
    }

    void Bake()
    {
        if (count == 0) return;
        clicker.Clicks += count * cookies;
    }

    public void Buy()
    {
        int roundedPrice = Mathf.CeilToInt(price);
        if(clicker.Clicks >= roundedPrice)
        {
            clicker.Clicks -= roundedPrice;
            count++;
            countText.text = count.ToString();
            price *= 1.2f; //increasing price by 20%
            priceText.text = $"Price: {Mathf.CeilToInt(price)}";
        }
    }
}
