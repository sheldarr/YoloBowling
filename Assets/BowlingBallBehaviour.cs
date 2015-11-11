using System;
using UnityEngine;

/// Created: 15/10/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 29/10/2015
/// LastModifiedBy: Rafał Ostrowski
/// Description: Script responsible for bowling ball's behaviour, e.g. its movement.
/// Keys: r - reset ball's position, w - move ball forward
/// Mouse buttons: left button pressed and released - logs time for how long it was pressed.
/// </summary>
public class BowlingBallBehaviour : MonoBehaviour
{
    /// <summary>
    /// The mouse left key
    /// </summary>
    private const int MouseLeftKey = 0;

    /// <summary>
    /// The forward key
    /// </summary>
    private const string ForwardKey = "w";

    /// <summary>
    /// The reset ball position key
    /// </summary>
    private const string ResetBallPositionKey = "r";

    /// <summary>
    /// The ball speed
    /// </summary>
    private const float BallSpeed = 5.0f;

    /// <summary>
    /// The mouse clicked time
    /// </summary>
    private int _mouseClickedTime;

    /// <summary>
    /// The object start position
    /// </summary>
    private Vector3 _objectStartPosition;

    /// <summary>
    /// Gets or sets a value indicating whether forward button is pressed.
    /// </summary>
    /// <value>
    /// <c>true</c> if forward button pressed; otherwise, <c>false</c>.
    /// </value>
    public bool IsForwardPressed { get; set; }

    /// <summary>
    /// Gets or sets the mouse click time in miliseconds.
    /// </summary>
    /// <value>
    /// The mouse click time in miliseconds.
    /// </value>
    public int MouseClickTimeInMiliseconds { get; set; }

    /// <summary>
    /// Initialization
    /// </summary>
    private void Start()
    {
        _objectStartPosition = GameObject.Find("Sphere").transform.position;
    }

    /// <summary>
    /// Updates is called once per frame
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(ForwardKey))
        {
            IsForwardPressed = true;
        }

        if (Input.GetKeyUp(ForwardKey))
        {
            IsForwardPressed = false;
        }

        if (Input.GetKeyDown(ResetBallPositionKey))
        {
            ResetBallPosition();
        }

        if (IsForwardPressed)
        {
            transform.Translate(Vector3.back * Time.deltaTime * BallSpeed);
        }

        if (LeftMouseWasClicked())
        {
            StartCountingHowLongMouseIsPressed();
        }

        if (LeftMouseWasReleased())
        {
            StopCountingHowLongMouseIsPressed();
            LogForHowLongMouseWasPressed();
        }
    }

    /// <summary>
    /// Resets the ball position.
    /// </summary>
    private void ResetBallPosition()
    {
        GameObject.Find("Sphere").transform.position = _objectStartPosition;
    }

    /// <summary>
    /// Starts the counting how long mouse is pressed.
    /// </summary>
    private void StartCountingHowLongMouseIsPressed()
    {
        MouseClickTimeInMiliseconds = 0;
        _mouseClickedTime = Environment.TickCount;
    }

    /// <summary>
    /// Stops the counting how long mouse is pressed.
    /// </summary>
    private void StopCountingHowLongMouseIsPressed()
    {
        int mouseReleaseTime = Environment.TickCount;
        MouseClickTimeInMiliseconds = mouseReleaseTime - _mouseClickedTime;
    }

    /// <summary>
    /// Just temporarily, to show that it was measured properly.
    /// </summary>
    private void LogForHowLongMouseWasPressed()
    {
        Debug.Log(string.Format("Left mouse button was pressed for: {0} ms", MouseClickTimeInMiliseconds));
    }

    /// <summary>
    /// Checks if left mouse button was clicked.
    /// </summary>
    private bool LeftMouseWasClicked()
    {
        return Input.GetMouseButtonDown(MouseLeftKey);
    }

    /// <summary>
    /// Checks if left mouse button was released.
    /// </summary>
    private bool LeftMouseWasReleased()
    {
        return Input.GetMouseButtonUp(MouseLeftKey);
    }
}