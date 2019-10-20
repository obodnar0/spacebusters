using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SateliteCounter : MonoBehaviour
{
    private InputField SatelCounter;
    private string prevVal;

    void Start()
    {
        SatelCounter = GameObject.Find("SatelitCounter").GetComponent<InputField>();
        prevVal = SatelCounter.text;
    }

    void Update()
    {
        try
        {
            List<GameObject> Satelites = new List<GameObject>();
            Satelites.Add(ObjectsStorage.Ints.Satel1);
            Satelites.Add(ObjectsStorage.Ints.Satel2);
            Satelites.Add(ObjectsStorage.Ints.Satel3);
            Satelites.Add(ObjectsStorage.Ints.Satel4);

            if (SatelCounter.text != prevVal)
            {
                for (int i = 0; i < Int32.Parse(SatelCounter.text); i++)
                {
                    Satelites[i].SetActive(true);
                }

                for (int i = Int32.Parse(SatelCounter.text); i < Satelites.Count; i++)
                {
                    Satelites[i].SetActive(false);
                }

                prevVal = SatelCounter.text;
            }
        }
        catch { }
    }
}
