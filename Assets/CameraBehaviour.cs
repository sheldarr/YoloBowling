using UnityEngine;

/// Created: 29/10/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 12/09/2015
/// LastModifiedBy: Kewin Polok
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

    public Camera DartCamera;

    /// <summary>
    /// Updates is called once per frame
    /// </summary>
    void Update () 
	{
		if (Input.GetKeyDown(KeyCode.F1)) 
		{
			SetMainCamera();
		}
		
		if (Input.GetKeyDown(KeyCode.F2)) 
		{
			SetTppCamera();
		}
		
		if (Input.GetKeyDown(KeyCode.F3))
		{
			SetFppCamera();
		}

        if (Input.GetKeyDown(KeyCode.F4))
        {
            SetDartCamera();
        }
    }

    /// <summary>
    /// Sets the main camera.
    /// </summary>
    private void SetMainCamera() 
	{
		MainCamera.enabled = true;

        FppCamera.enabled = false;
        TppCamera.enabled = false;
        DartCamera.enabled = false;
    }

    /// <summary>
    /// Sets the TPP camera.
    /// </summary>
    private void SetTppCamera() 
	{
		TppCamera.enabled = true;

        MainCamera.enabled = false;
        FppCamera.enabled = false;
        DartCamera.enabled = false;
    }

    /// <summary>
    /// Sets the FPP camera.
    /// </summary>
    private void SetFppCamera() 
	{
		FppCamera.enabled = true;

        MainCamera.enabled = false;
        TppCamera.enabled = false;
        DartCamera.enabled = false;
    }

    private void SetDartCamera()
    {
        DartCamera.enabled = true;

        MainCamera.enabled = false;
        TppCamera.enabled = false;
        FppCamera.enabled = false;
    }
}
