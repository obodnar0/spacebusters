using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunRadiusSliderScript : MonoBehaviour
{
	private Slider _sunRadiusSlider;

	void Start()
	{
		_sunRadiusSlider = GameObject.Find("SRSlider").GetComponent<Slider>();
	}

	void Update()
	{
		PlanetConfigurator.StarRadius = _sunRadiusSlider.value;
	}
}
