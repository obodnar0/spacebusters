using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SateliteSlider : MonoBehaviour
{
    private Slider SateliteSliderInstance;
    private int prevVal = -1;

    void Start()
    {
        SateliteSliderInstance = GameObject.Find("SatelitSlider").GetComponent<Slider>();
    }

    void Update()
    {
        var val = (int)SateliteSliderInstance.value;
        if (prevVal == val)
            return;

        List<GameObject> Satelites = new List<GameObject>();
        Satelites.Add(ObjectsStorage.Ints.Satel1);
        Satelites.Add(ObjectsStorage.Ints.Satel2);
        Satelites.Add(ObjectsStorage.Ints.Satel3);
        Satelites.Add(ObjectsStorage.Ints.Satel4);

        for (int i = 0; i < val; i++)
        {
            Satelites[i].SetActive(true);
        }

        for (int i = val; i < Satelites.Count; i++)
        {
            Satelites[i].SetActive(false);
        }
    }
}
