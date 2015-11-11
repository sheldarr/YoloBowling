using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CameraBehaviour : MonoBehaviour 
{
    /// <summary>
    /// The default camera
    /// </summary>
    private Camera MainCamera;
    private Camera TppCamera;
    private Camera FppCamera;

    /// <summary>
    /// The default camera key
    /// </summary>
    private const string DefaultCameraKey = "f1";
    private const string FppCameraKey = "f2";
    private const string TppCameraKey = "f3";

    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start () 
	{
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        FppCamera = GameObject.Find("FppCamera").GetComponent<Camera>();
        TppCamera = GameObject.Find("TppCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
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
