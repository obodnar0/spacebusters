using System;
using Assets.Scripts;
using UnityEngine;

public class PlanetConfigurator : MonoBehaviour
{
    public Material[] _materials;
    private Renderer _rend;

    public const float JupyterMass = (float) (1.9 * 1e27);
    public const float JupyterRadius = (float) (7 * 1e4);

    private static float _starDistance = 50000000;
    private static float _starRadius = 1000;
    private static float _starTemperature = 2000;


    private static float _planetTemperature = 100;

    public static float StarDistance
    {
	    get => _starDistance;
	    set
	    {
		    if (Math.Abs(_starDistance - value) > 1e-9)
		    {
			    _starDistance = value;
			    CheckPlanetTemperature();
			}
	    }
    }

    public static float StarRadius
    {
	    get => _starRadius;
	    set
	    {
			if (Math.Abs(_starRadius - value) > 1e-9)
			{
				_starRadius = value;
				CheckPlanetTemperature();
			}
		}
    }

    public static float StarTemperature
    {
	    get => _starTemperature;
	    set
	    {
			if (Math.Abs(_starTemperature - value) > 1e-9)
			{
				_starTemperature = value;
				CheckPlanetTemperature();
			}
		}
    }

    public static float Radius = 1;
    private static float PrevX;
    private static float PrevY;
    public static float Mass = 1000;



    public static void CheckPlanetTemperature()
    {
	    var link = "https://www.lpi.usra.edu/education/explore/our_place/hab_ref_table.pdf";
		var temperature = (float) CalculateTemperatureEquilibrium(_starTemperature, _starRadius, _starDistance, 0.29f);
	    if (temperature >= 400)
	    {
		    MessageCenter.Show("Causes temperature about 125oC and higher, protein and carbohydrate molecules and genetic material (e.g., DNA and RNA) start to break apart. Also, high temperatures quickly evaporate water.", "high", link);
	    }
		else if (temperature >= 200)
	    {
		    MessageCenter.Show("Great! life seems limited to a temperature range of minus 15oC to 115oC. In this range, liquid water can still exist under certain conditions.", "ok",link);
	    }
		else
	    {
		    MessageCenter.Show("Low temperatures cause chemicals to react slowly, which interferes with the reactions necessary for life. Also low temperatures freeze water, making liquid water unavailable.", "low",link);
	    }

	    _planetTemperature = temperature;
    }

    public static double CalculateTemperatureEquilibrium(float starTemperature, float starRadius, float orbitalDistance, float bondAlbedo)
    {
	    var res = starTemperature * Math.Sqrt(starRadius / (2 * orbitalDistance)) * Math.Pow(1 - bondAlbedo, 0.25);

	    return res;
    }

	public static void SetTemperature(float temp)
    {
        StarTemperature = temp;
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
        if (from > _planetTemperature || _planetTemperature >= to)
            return;

        var first = _rend.Material(materialNameFirst);
        var second = _rend.Material(materialNameSecond);
        var opasity = ((_planetTemperature - from) / (to - from)).Range(0, 1);

        first.color = first.color.Opacity(1 - opasity);
        second.color = second.color.Opacity(opasity);
    }

    void SetMaterialForTemperature(string materialName, float from, float to)
    {
        var material = _rend.Material(materialName);

        material.color = material.color.Opacity(from > StarTemperature || StarTemperature >= to ? 0 : 1);
    }

    void Update()
    {
        SetMaterialForTemperature("FrozenPlanetTexture", 0, 100);
        SetMaterialForTemperature("PlanetTexture", 100, 230);
        SetMaterialForTemperature("Earth", 230, 400);
        SetMaterialForTemperature("HotPlanet", 400, 2000);

        SetMaterialGradient("FrozenPlanetTexture", "PlanetTexture", 0, 100);
        SetMaterialGradient("PlanetTexture", "Earth", 100, 230);
        SetMaterialGradient("Earth", "HotPlanet", 230, 400);

        EarthAtmosphere.ChangeTransparency(_rend.Material("Earth").color.a);

        float gs = Radius;
        _rend.transform.localScale = new Vector3(gs, gs, gs);
	}
}
