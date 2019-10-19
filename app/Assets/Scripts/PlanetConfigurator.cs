using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetConfigurator : MonoBehaviour
{
    public Material[] _materials;
    private Renderer _rend;
    

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.enabled = true;
        _rend.sharedMaterial = _materials[0];
    }

    void OnMouseDown()
    {
        CameraRotator.ResetPrev();
        CameraRotator.IsPressed = true;
    }

    void OnMouseUp()
    {
        CameraRotator.IsPressed = false;
    }

    void Update()
    {
    }
}
