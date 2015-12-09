using UnityEngine;

/// <summary>
/// Created: 15/10/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 09/12/2015
/// LastModifiedBy: Kewin Polok
/// Description: Handles the controls for camera changing
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
    /// The dart camera
    /// </summary>
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

    /// <summary>
    /// Sets the dart camera.
    /// </summary>
    private void SetDartCamera()
    {
        DartCamera.enabled = true;

        MainCamera.enabled = false;
        TppCamera.enabled = false;
        FppCamera.enabled = false;
    }
}
