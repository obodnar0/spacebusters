using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetRadiusScript : MonoBehaviour
{
    private Slider RadSlider;

    void Start()
    {
        RadSlider = GameObject.Find("RSlider").GetComponent<Slider>();
    }

    void Update()
    {
        PlanetConfigurator.SetRadius(RadSlider.value);
        EarthAtmosphere.SetRadius(RadSlider.value);
    }
}
