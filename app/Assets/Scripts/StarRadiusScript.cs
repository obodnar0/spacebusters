using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class StarRadiusScript : MonoBehaviour
{
    private Slider RadSlider;

    void Start()
    {
        RadSlider = GameObject.Find("SRSlider").GetComponent<Slider>();
    }

    void Update()
    {
        var gs = RadSlider.value / 1000;
        ObjectsStorage.Ints.Star.transform.localScale = new Vector3(-gs,-gs,-gs);
    }
}
