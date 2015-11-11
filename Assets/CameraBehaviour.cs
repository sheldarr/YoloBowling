using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CameraBehaviour : MonoBehaviour 
{
    /// <summary>
    /// The default camera
    /// </summary>
    public Camera DefaultCamera, TppCamera,  FppCamera;
    /// <summary>
    /// The default camera key
    /// </summary>
    private const string DefaultCameraKey = "f1", TppCameraKey = "f2",  FppCameraKey = "f3";

    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start () 
	{
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
			Debug.Log("f1 down");
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
		DefaultCamera.enabled = true;
		TppCamera.enabled = FppCamera.enabled = false;
	}

    /// <summary>
    /// Sets the TPP camera.
    /// </summary>
    private void SetTppCamera() 
	{
		TppCamera.enabled = true;
		DefaultCamera.enabled = FppCamera.enabled = false;
	}

    /// <summary>
    /// Sets the FPP camera.
    /// </summary>
    private void SetFppCamera() 
	{
		FppCamera.enabled = true;
		TppCamera.enabled = DefaultCamera.enabled = false;
	}
}
