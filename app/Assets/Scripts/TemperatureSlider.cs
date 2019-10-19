using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureSlider : MonoBehaviour
{
    private Slider TempSlider;

    void Start()
    {
        TempSlider = GameObject.Find("TSlider").GetComponent<Slider>();
    }

    void Update()
    {
        PlanetConfigurator.Temperature = TempSlider.value;  
    }
}
