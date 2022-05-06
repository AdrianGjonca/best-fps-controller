using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollishedFPSController : CharacterController
{
  public Camera CameraPrefab; //This is a prefab that will be used for the player camera
  
  private GameObject playersCamera; //The camera the player looks through. It is created in code.
  void Start()
  {
    this.center = new Vector3(0,1,0); //Transform position at player's feet
    this.height = 2f;
    this.radius = 0.5f; //These two values should be set to unity's default
    
    playersCamera = 
      Instantiate(
        CameraPrefab.gameObject, 
        this.transform
      ); //Creates a camera with this as it's parent
    playersCamera.transform.localPosition = new Vector3(0, 1.8, 0);//Positions camera 1.8m above feet
    
    lookDirection = new Vector2(0,0);
  }
  
  private Vector2 lookDirection; //Holds the direction the player is looking. 1 unity = 360 deg
  void Update()
  {
    Quaternion bodyRotation = Quaternion.Euler(0, 0, 0);
    Quaternion cameraRotation = Quaternion.Euler(0, 0, 0); //tbc
  }
}
