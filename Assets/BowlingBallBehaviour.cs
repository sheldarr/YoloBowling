using UnityEngine;

/// <summary>
/// Created: 15/10/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 09/12/2015
/// LastModifiedBy: Kewin Polok
/// Description: Script responsible for bowling ball's behaviour, e.g. its movement.
/// Keys: r - reset ball's position, w - move ball forward
/// Mouse buttons: left button pressed and released - logs time for how long it was pressed.
/// </summary>
public class BowlingBallBehaviour : MonoBehaviour
{
    /// <summary>
    /// The ball speed
    /// </summary>
    private const float ForwardTorque = 10.0f;

    private const float SideForce = 4.0f;

    private const float MaxAfterBurnerPower = 10;

    private float AfterburnerPower { get; set; }

    /// <summary>
    /// The object start position
    /// </summary>
    private Vector3 _startPosition;

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