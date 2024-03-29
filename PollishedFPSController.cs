using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollishedFPSController : MonoBehaviour
{
	public Camera    CameraPrefab;     //This is a prefab that will be used for the player camera
	
	private GameObject            playersCamera;   //The camera the player looks through. It is created in code.
	private CharacterController   controller;      //The Unity CharacterController component that deals with collision and movement.

	void Start()
	{
		controller   = gameObject.AddComponent<CharacterController>(); //Creates the thing

		controller.center   = new Vector3(0, 1, 0); //Transform position at player's feet
		controller.height   = 2f;
		controller.radius   = 0.5f; //These two values should be set to unity's default

		playersCamera                           = Instantiate( CameraPrefab.gameObject, this.transform ); //Creates a camera with this as it's parent
		playersCamera.name                      = "Player Camera";
		playersCamera.transform.localPosition   = new Vector3(0, 1.8f, 0);//Positions camera 1.8m above feet

		lookDirection   = new Vector2(0, 0);
	}

	private Vector2 lookDirection; //Holds the direction the player is looking. 1 unit = 360 deg
	
	void Update()
	{
		lookDirection     += Vector2.right * Input.GetAxis("Mouse X") * Time.deltaTime;
		lookDirection     += Vector2.up * Input.GetAxis("Mouse Y")    * Time.deltaTime;

		lookDirection.y   =  Mathf.Clamp(lookDirection.y, -0.25f, 0.25f);

		Quaternion bodyRotation     =  Quaternion.Euler(0, lookDirection.x * 360f, 0);
		Quaternion cameraRotation   =  Quaternion.Euler(lookDirection.y * 360f, lookDirection.x * 360f, 0);

		playersCamera.transform.rotation   =  cameraRotation;
		transform.rotation                 =  bodyRotation;
	}
}
