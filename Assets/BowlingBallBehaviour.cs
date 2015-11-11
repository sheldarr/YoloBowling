using System;
using UnityEngine;

/// <summary>
/// Responsible for bowling ball's behaviour, f.e. its movement.
/// Keys:
/// r - reset ball's position.
/// w - move ball forward
/// Mouse buttons:
/// left key pressed and released - logs time for how long it was pressed.
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
    private const string ForwardKey = "w", ResetBallPositionKey = "r";
    /// <summary>
    /// The ball speed
    /// </summary>
    private const float BallSpeed = 5.0f;

    /// <summary>
    /// The _mouse clicked time
    /// </summary>
    private int _mouseClickedTime;
    /// <summary>
    /// The _object start position
    /// </summary>
    private Vector3 _objectStartPosition;

    /// <summary>
    /// Gets or sets a value indicating whether this instance is forward pressed.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is forward pressed; otherwise, <c>false</c>.
    /// </value>
    public bool IsForwardPressed { get; set; }
    /// <summary>
    /// Gets or sets the mouse click time in miliseconds.
    /// </summary>
    /// <value>
    /// The mouse click time in miliseconds.
    /// </value>
    public int MouseClickTimeInMiliseconds { get; set; }

    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    private void Start()
    {
        _objectStartPosition = GameObject.Find("Sphere").transform.position;
    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
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
    /// Lefts the mouse was clicked.
    /// </summary>
    /// <returns></returns>
    private bool LeftMouseWasClicked()
    {
        return Input.GetMouseButtonDown(MouseLeftKey);
    }

    /// <summary>
    /// Lefts the mouse was released.
    /// </summary>
    /// <returns></returns>
    private bool LeftMouseWasReleased()
    {
        return Input.GetMouseButtonUp(MouseLeftKey);
    }
}