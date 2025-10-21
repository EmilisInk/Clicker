using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoClicker : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI countText;

    [Header("Settings")]
    public float bakeOffset = 2;
    public int cookies = 1;
    public int count = 0;
    public float price = 50;

    [Header("Clicker")]
    public Clicker clicker;

    public Image image;

    public int autoClickerRate = 3;

    private void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        priceText.text = $"Price: {price}";
        countText.text = count.ToString();
        InvokeRepeating(nameof(Autoclicker), bakeOffset, bakeOffset);
    }

    void Autoclicker()
    {
        image.enabled=true;
        if (count > 0)
        {
            clicker.Clicks += (count * cookies);
        }
    }

    public void Buy()
    {
        int roundedPrice = Mathf.CeilToInt(price);
        if (clicker.Clicks >= roundedPrice)
        {
            clicker.Clicks -= roundedPrice;
            count++;
            countText.text = count.ToString();
            price *= 1.5f; //increasing price by 20%
            priceText.text = $"Price: {Mathf.CeilToInt(price)}";
        }
    }
}
