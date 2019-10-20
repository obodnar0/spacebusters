using System;
using Assets.Scripts;
using UnityEngine;

public class PlanetConfigurator : MonoBehaviour
{
    public Material[] _materials;
    private Renderer _rend;

    public const float JupyterMass = (float) (1.9 * 1e27);
    public const float JupyterRadius = (float) (7 * 1e4);

    public static float Temperature = 10;
    public static float Radius = 1000;
    public static float Mass = 1000;

    public static void SetTemperature(float temp)
    {
        Temperature = temp;
    }

    public static void SetRadius(float radius)
    {
        Radius = radius;
    }

    public static bool IsGasGiant()
    {
	    var density = CalculateDensity(Mass * JupyterMass, Radius * JupyterRadius);
	    return density < 1.64;
    }

    public static double CalculateDensity(double mass, double radius)
    {
	    var volume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

	    return mass  / volume;
    }

	void Start()
    {
        //ObjectsStorage.Ints.Planet = gameObject;
        _rend = GetComponent<Renderer>();
        _rend.enabled = true;
        _materials = _rend.sharedMaterials;
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

    void SetMaterialGradient(string materialNameFirst, string materialNameSecond, float from, float to)
    {
        if (from > Temperature || Temperature >= to)
            return;

        var first = _rend.Material(materialNameFirst);
        var second = _rend.Material(materialNameSecond);
        var opasity = ((Temperature - from) / (to - from)).Range(0, 1);

        first.color = first.color.Opacity(1 - opasity);
        second.color = second.color.Opacity(opasity);
    }

    void SetMaterialForTemperature(string materialName, float from, float to)
    {
        var material = _rend.Material(materialName);

        material.color = material.color.Opacity(from > Temperature || Temperature >= to ? 0 : 1);
    }

    void Update()
    {
        SetMaterialForTemperature("FrozenPlanetTexture", -280, -85);
        SetMaterialForTemperature("PlanetTexture", -65, -5);
        SetMaterialForTemperature("Earth", 15, 110);
        SetMaterialForTemperature("HotPlanet", 130, 600);

        SetMaterialGradient("FrozenPlanetTexture", "PlanetTexture", -85, -65);
        SetMaterialGradient("PlanetTexture", "Earth", -5, 15);
        SetMaterialGradient("Earth", "HotPlanet", 110, 130);

        EarthAtmosphere.ChangeTransparency(_rend.Material("Earth").color.a);

        float gs = Radius / 1000;
        _rend.transform.localScale = new Vector3(gs, gs, gs);
    }
}
