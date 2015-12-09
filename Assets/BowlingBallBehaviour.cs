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

    /// <summary>
    /// The object start position
    /// </summary>
    private Vector3 _startPosition;

    /// <summary>
    /// Initialization
    /// </summary>
    private void Start()
    {
        _startPosition = gameObject.transform.position;
    }

    /// <summary>
    /// Updates is called once per frame
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(-transform.right * ForwardTorque);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.right * SideForce);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.right * SideForce);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBallState();
        }
    }

    /// <summary>
    /// Resets the ball position.
    /// </summary>
    private void ResetBallState()
    {
        gameObject.transform.position = _startPosition;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}