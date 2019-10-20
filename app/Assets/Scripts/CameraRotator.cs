using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotator : MonoBehaviour
{
	//public float speed;
	//public float scale = 1;
	public static bool IsPressed = false;
	private static float PrevX;
	private static float PrevY;
	private static float MovementValue = float.NaN;
	public static bool IsMovementRequired;


	public Renderer target;//the target object
	private GameObject camera;
	private float speedMod = 3.0f;//a speed modifier
	private Vector3 point;//the coord to the point where the camera looks at
	float minFov = 10f;
	float maxFov = 900000f;
	float sensitivity = 10f;
	void Start()
	{//Set up things on the start method

		target = GameObject
			.Find( "Planet" )
			.GetComponent<Renderer>();
		camera = GameObject
			.Find( "Main Camera" );
		point = target.transform.position;//get target's coords
		transform.LookAt( point );//makes the camera look to it
	}

	public static void ResetPrev()
	{
		PrevX = Input.mousePosition.x;
		PrevY = Input.mousePosition.y;
	}

	public static void MoveZ( float value )
	{
		IsMovementRequired = true;
		MovementValue = value;
	}


	void Update()
	{
		if( IsPressed )
		{
			//transform.RotateAround(
			//	point,
			//	new Vector3( ( PrevY - Input.mousePosition.y % 360 ), -( PrevX - Input.mousePosition.x % 360 ), 0.0f ),
			//	20 * Time.deltaTime * speedMod
			//);

			//Vector3 desiredPosition = target.transform.position;
			//Vector3 smoothedPosition = Vector3.Lerp( transform.position, desiredPosition, speedMod );
			//transform.position = smoothedPosition;
			//transform.LookAt( target.transform.position );

			transform.Rotate( ( PrevY - Input.mousePosition.y % 360 ), -( PrevX - Input.mousePosition.x % 360 ), 0 );
			PrevX = Input.mousePosition.x;
			PrevY = Input.mousePosition.y;
		}
		else
		{

		}


		//if( Input.GetAxis( "Mouse ScrollWheel" ) != 0f ) // forward
		{
			//transform.m
			transform.LookAt( target.transform.position );

			camera.transform.position += new Vector3( 0, 0, Input.GetAxis( "Mouse ScrollWheel" ) );


			//float fov = Camera.main.fieldOfView;
			//fov += Input.GetAxis( "Mouse ScrollWheel" ) * sensitivity;
			//fov = Mathf.Clamp( fov, minFov, maxFov );
			//Camera.main.fieldOfView = fov;
		}
	}
}
