using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    public void OnValueChanged(int currentValue, int maxValue)
    {
        Slider.value = (float)currentValue / maxValue;
    }
}