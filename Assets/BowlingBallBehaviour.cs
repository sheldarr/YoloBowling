using UnityEngine;

/// <summary>
/// Created: 15/10/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 09/12/2015
/// LastModifiedBy: Kewin Polok
/// Description: Script responsible for bowling ball's behaviour, e.g. its movement.
/// </summary>
public class BowlingBallBehaviour : MonoBehaviour
{
    /// <summary>
    /// The ball speed
    /// </summary>
    private const float ForwardTorque = 10.0f;

    /// <summary>
    /// The side force
    /// </summary>
    private const float SideForce = 4.0f;

    /// <summary>
    /// The maximum afterburner power
    /// </summary>
    private const float MaxAfterBurnerPower = 10;

    /// <summary>
    /// Gets or sets the afterburner power.
    /// </summary>
    /// <value>
    /// The afterburner power.
    /// </value>
    private float AfterburnerPower { get; set; }

    /// <summary>
    /// The start position
    /// </summary>
    private Vector3 _startPosition;

    /// <summary>
    /// The start rotation
    /// </summary>
    private Quaternion _startRotation;

    /// <summary>
    /// Initialization
    /// </summary>
    private void Start()
    {
        _startPosition = gameObject.transform.position;
        _startRotation = gameObject.transform.rotation;

        AfterburnerPower = 0f;
    }

    /// <summary>
    /// Updates is called once per frame
    /// </summary>
    private void Update()
    {
        HandleAfterburnerControls();

        HandleAfterburnerColors();

        HandleMovingControls();

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBallState();
        }
    }

    /// <summary>
    /// Handles the moving controls.
    /// </summary>
    private void HandleMovingControls()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(-transform.right*ForwardTorque);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(transform.right*ForwardTorque);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.right*SideForce);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.right*SideForce);
        }
    }

    /// <summary>
    /// Handles the afterburner colors.
    /// </summary>
    private void HandleAfterburnerColors()
    {
        if (AfterburnerPower <= MaxAfterBurnerPower)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (AfterburnerPower <= 0.75*MaxAfterBurnerPower)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (AfterburnerPower <= 0.50*MaxAfterBurnerPower)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        if (AfterburnerPower <= 0.25*MaxAfterBurnerPower)
        {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
    }

    /// <summary>
    /// Handles the afterburner controls.
    /// </summary>
    private void HandleAfterburnerControls()
    {
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            if (AfterburnerPower > 0)
            {
                Debug.Log(AfterburnerPower);
                gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward*AfterburnerPower, ForceMode.VelocityChange);
            }

            AfterburnerPower = 0f;
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.UpArrow) && AfterburnerPower <= MaxAfterBurnerPower)
        {
            AfterburnerPower += MaxAfterBurnerPower/100;
        }
    }

    /// <summary>
    /// Resets the ball state.
    /// </summary>
    private void ResetBallState()
    {
        gameObject.transform.position = _startPosition;
        gameObject.transform.rotation = _startRotation;

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}