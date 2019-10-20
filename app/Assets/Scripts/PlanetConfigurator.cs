using Assets.Scripts;
using UnityEngine;

public class PlanetConfigurator : MonoBehaviour
{
    public Material[] _materials;
    private Renderer _rend;

    public static float Temperature = 10;
    public static float Radius = 1000;

    public static void SetTemperature(float temp)
    {
        Temperature = temp;
    }

    public static void SetRadius(float radius)
    {
        Radius = radius;
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
