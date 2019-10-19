using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class PlanetConfigurator : MonoBehaviour
{
    public Material[] _materials;
    private Renderer _rend;


    public static double Temperature = 10;
    public static float Radius = 1000;

    public static void SetTemperature(double temp)
    {
        Temperature = temp;
    }

    public static void SetRadius(float radius)
    {
        Radius = radius;
    }

    void Start()
    {
        ObjectsStorage.Ints.Planet = gameObject;
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



    void UpdateMaterial(string name)
    {
       
    }

    void Update()
    {
        float gs = Radius / 1000;
        _rend.transform.localScale = new Vector3(gs, gs, gs);
        if (Temperature < -80)
        {
            UpdateMaterial("FrozenPlanetTexture");
        }

        if (Temperature > -80 && Temperature < 0)
        {
            UpdateMaterial("PlanetTexture");
        }

        if (Temperature > 0 && Temperature < 120)
        {
            UpdateMaterial("Earth");
        }

        if (Temperature > 120)
        {
            UpdateMaterial("HotPlanet");
        }
    }
}
