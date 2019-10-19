using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEditor;
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
        ObjectsStorage.Ints.Satel1.transform.position = new Vector3((float)1.3 + (RadSlider.value / 1000 - 1), ObjectsStorage.Ints.Satel1.transform.position.y, ObjectsStorage.Ints.Satel1.transform.position.z);
        ObjectsStorage.Ints.Satel2.transform.position = new Vector3((float)1 - (RadSlider.value / 1000 - 1), 1 + (RadSlider.value / 1000 - 1), ObjectsStorage.Ints.Satel1.transform.position.z);
        ObjectsStorage.Ints.Satel3.transform.position = new Vector3(ObjectsStorage.Ints.Satel1.transform.position.x, (float)-1.4 - (RadSlider.value / 1000 + 1), ObjectsStorage.Ints.Satel1.transform.position.z);
        ObjectsStorage.Ints.Satel4.transform.position = new Vector3(ObjectsStorage.Ints.Satel1.transform.position.x, (float)1.5 + (RadSlider.value / 1000 - 1), ObjectsStorage.Ints.Satel1.transform.position.z);
        PlanetConfigurator.SetRadius(RadSlider.value);
        EarthAtmosphere.SetRadius(RadSlider.value);
    }
}
