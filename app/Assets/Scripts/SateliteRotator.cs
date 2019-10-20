using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SateliteRotator : MonoBehaviour
{
    public float Speed;

    public void Update()
    {
        switch (transform.GetChild(0).name)
        {
            case "S1":
                ObjectsStorage.Ints.Satel1 = gameObject;
                break;
            case "S2":
                ObjectsStorage.Ints.Satel2 = gameObject;
                break;
            case "S3":
                ObjectsStorage.Ints.Satel3 = gameObject;
                break;
            case "S4":
                ObjectsStorage.Ints.Satel4 = gameObject;
                break;
        }
        transform.Rotate((Speed - 2) * Time.deltaTime, Speed * Time.deltaTime, 0);
    }
}
