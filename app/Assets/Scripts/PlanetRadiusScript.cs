using System;
using UnityEngine;
using UnityEngine.UI;

public class PlanetRadiusScript : MonoBehaviour
{

	private const float MinRadiumU = 0.06f;//0.003;
	private Slider _radSlider;
	private Text _text;
	private float _previousRadiusValue = MinRadiumU;

	private void Start()
	{
		_radSlider = GameObject
			.Find( "RSlider" )
			.GetComponent<Slider>();
		_text = GameObject
			.Find( "RSlider" )
			.GetComponentInChildren<Text>();
	}

	private void Update()
	{
		//ObjectsStorage.Ints.Satel1.transform.position = new Vector3((float)1.3 + (RadSlider.value / 1000 - 1), ObjectsStorage.Ints.Satel1.transform.position.y, ObjectsStorage.Ints.Satel1.transform.position.z);
		//ObjectsStorage.Ints.Satel2.transform.position = new Vector3((float)1 - (RadSlider.value / 1000 - 1), 1 + (RadSlider.value / 1000 - 1), ObjectsStorage.Ints.Satel1.transform.position.z);
		//ObjectsStorage.Ints.Satel3.transform.position = new Vector3(ObjectsStorage.Ints.Satel1.transform.position.x, (float)-1.4 - (RadSlider.value / 1000 + 1), ObjectsStorage.Ints.Satel1.transform.position.z);
		//ObjectsStorage.Ints.Satel4.transform.position = new Vector3(ObjectsStorage.Ints.Satel1.transform.position.x, (float)1.5 + (RadSlider.value / 1000 - 1), ObjectsStorage.Ints.Satel1.transform.position.z);

		float value = _radSlider.value;
		value *= 20;

		//if( Math.Abs( _previousRadiusValue - value ) < 0.001 )
		//{
		//	return;
		//}


		if( Math.Abs( _previousRadiusValue - value ) >= 0.001 )
		{
			CameraRotator.MoveZ( _previousRadiusValue > value
				? -value
				: value
			);
			_previousRadiusValue = value;
		}


		PlanetConfigurator.SetRadius( value );
		EarthAtmosphere.SetRadius( value );
		UpdateRadiusText( _radSlider.value );

	}

	private void UpdateRadiusText( float value )
	{
		double jupiterRadious = 10.97;//Earth R

		_text.text = $"Planet radius: { ( value * jupiterRadious ) :0.00} Jupiter R ({ value.ToString() } Jupiter R)";
	}
}
