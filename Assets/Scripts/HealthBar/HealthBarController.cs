using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject healthBarCanvas;

    public void setMaxHealth(float h)
    {
        slider.maxValue =h;
        slider.value = h;
        fill.color = gradient.Evaluate(1.0f);
    }
    public void setHealth(int h)
    {
        slider.value = h;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
