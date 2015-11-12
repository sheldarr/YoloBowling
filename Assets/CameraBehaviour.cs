using UnityEngine;

/// Created: 29/10/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 29/10/2015
/// LastModifiedBy: Rafał Ostrowski
/// Description: Script for switching the view between cameras
/// Keys: F1 - Main camera, F2 - TPP Camera, F3- FPP Camera
/// </summary>
public class CameraBehaviour : MonoBehaviour 
{
    /// <summary>
    /// The default camera
    /// </summary>
    public Camera MainCamera;
    /// <summary>
    /// The TPP camera
    /// </summary>
    public Camera TppCamera;
    /// <summary>
    /// The FPP camera
    /// </summary>
    public Camera FppCamera;

    /// <summary>
    /// The default camera key
    /// </summary>
    private const string DefaultCameraKey = "f1";
    /// <summary>
    /// The FPP camera key
    /// </summary>
    private const string FppCameraKey = "f2";
    /// <summary>
    /// The TPP camera key
    /// </summary>
    private const string TppCameraKey = "f3";

    /// <summary>
    /// Initialization
    /// </summary>
    void Start () 
	{

    }

    /// <summary>
    /// Updates is called once per frame
    /// </summary>
    void Update () 
	{
		if (Input.GetKeyDown(DefaultCameraKey)) 
		{
			SetDefaultCamera();
		}
		
		if (Input.GetKeyDown(TppCameraKey)) 
		{
			SetTppCamera();
		}
		
		if (Input.GetKeyDown(FppCameraKey))
		{
			SetFppCamera();
		}
	}

    /// <summary>
    /// Sets the default camera.
    /// </summary>
    private void SetDefaultCamera() 
	{
		MainCamera.enabled = true;

        FppCamera.enabled = false;
        TppCamera.enabled = false;
	}

    /// <summary>
    /// Sets the TPP camera.
    /// </summary>
    private void SetTppCamera() 
	{
		TppCamera.enabled = true;

        MainCamera.enabled = false;
        FppCamera.enabled = false;
	}

    /// <summary>
    /// Sets the FPP camera.
    /// </summary>
    private void SetFppCamera() 
	{
		FppCamera.enabled = true;

        MainCamera.enabled = false;
        TppCamera.enabled = false;
	}
}
