using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarRhino : MonoBehaviour
{
    // Objeto slider
    public Slider slider;

    //Objeto fill
    public Image fill;

    // Máximo de vida y valor del slider, a vida
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Asignar vida al valor del slider
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
