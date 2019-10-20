using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMassSliderScript : MonoBehaviour
{
	public const float MinHabitualMass = (float)(3 * 1e-4);
	public const float MaxHabitualMass = (float)(9 * 1e-2);

	private Slider _planetMassSlider;
	private float _previousValue;

	void Start()
    {
	    _planetMassSlider = GameObject.Find("PlanetMassSlider").GetComponent<Slider>();
	    _previousValue = _planetMassSlider.value;
    }
	
    void Update()
    {
	    var value = _planetMassSlider.value / (float) 1e5;
	    PlanetConfigurator.Mass = value;
	    if (Math.Abs(value - _previousValue) > 1e-9)
	    {
		    ScheduleAlert(value);
		    _previousValue = value;
	    }
		
    }

    void ScheduleAlert(float value)
    {
	    var link = "https://www.lpi.usra.edu/education/explore/our_place/hab_ref_table.pdf";

	    if (PlanetConfigurator.IsGasGiant())
	    {
		    MessageCenter.Show(GasGiantAlertText, GasGiantAlertTitle, link);
		}
		else if (value >= MaxHabitualMass)
	    {
			MessageCenter.Show(LargeMassAlertText, LargeMassAlertTitle, link);
		}
		else if (value >= MinHabitualMass)
	    {
		    MessageCenter.Show(OkMassAlertText, OkMassAlertTitle, link);
	    }
		else
	    {
		    MessageCenter.Show(SmallMassAlertText, SmallMassAlertTitle, link);
		}
	}

	// content

	// small mass
	public const string SmallMassAlertText =
		@"
		Small planets and moons have insufficient gravity to hold an atmosphere. 
		The gas molecules escape to space, leaving the planet or moon without an
		insulating blanket or a protective shield.
		";
	public const string SmallMassAlertTitle = "Small Planet Dimensions";

	// ok mass
	public const string OkMassAlertText =
		@"
		This is the right size to hold a sufficient-sized atmosphere. Earth’s atmosphere 
		is about 100 miles thick. It keeps the surface warm & protects it from radiation
		& small- to medium-sized meteorites.
		";
	public const string OkMassAlertTitle = "Normal Planet Dimensions";

	// large mass
	public const string LargeMassAlertText = 
		@"
		Atmosphere is much thicker than normal. It is made almost entirely of greenhouse
		gasses, making the surface too hot for life. The giant planets are completely made 
		of gas.
		";
	public const string LargeMassAlertTitle = "Large Planet Dimensions";

	public const string GasGiantAlertText =
		@"
		Planet's density is low. Most probably it is a gas giant. There is no life possible
		possible there
		";
	public const string GasGiantAlertTitle = "Gas giant";
}
