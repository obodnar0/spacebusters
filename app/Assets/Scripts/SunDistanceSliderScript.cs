using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunDistanceSliderScript : MonoBehaviour
{
	private Slider _sunDistanceSlider;

	void Start()
	{
		_sunDistanceSlider = GameObject.Find("DSlider").GetComponent<Slider>();
	}

	void Update()
	{
		PlanetConfigurator.StarDistance = _sunDistanceSlider.value;
	}
}
