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
    private const int MouseLeftKey = 0;
    private const string ForwardKey = "w", ResetBallPositionKey = "r";
    private const float BallSpeed = 5.0f;

    private int _mouseClickedTime;
    private Vector3 _objectStartPosition;

    public bool IsForwardPressed { get; set; }
    public int MouseClickTimeInMiliseconds { get; set; }

    // Use this for initialization
    private void Start()
    {
        _objectStartPosition = GameObject.Find("Sphere").transform.position;
    }

    // Update is called once per frame
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

    private void ResetBallPosition()
    {
        GameObject.Find("Sphere").transform.position = _objectStartPosition;
    }

    private void StartCountingHowLongMouseIsPressed()
    {
        MouseClickTimeInMiliseconds = 0;
        _mouseClickedTime = Environment.TickCount;
    }

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

    private bool LeftMouseWasClicked()
    {
        return Input.GetMouseButtonDown(MouseLeftKey);
    }

    private bool LeftMouseWasReleased()
    {
        return Input.GetMouseButtonUp(MouseLeftKey);
    }
}